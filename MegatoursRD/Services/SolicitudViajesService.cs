using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class SolicitudViajesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursiones
                             .AnyAsync(c => c.SolicitudViajeId == id);
    }

    private async Task<bool> Insertar(SolicitudViajes excursion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        contexto.SolicitudExcursiones.Add(excursion);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(SolicitudViajes excursion)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();

        _context.SolicitudExcursiones.Update(excursion);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(SolicitudViajes excursion)
    {
        if (!await Existe(excursion.SolicitudViajeId))
            return await Insertar(excursion);
        else
            return await Modificar(excursion);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursiones
            .Where(c => c.SolicitudViajeId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<SolicitudViajes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursiones
            .FirstOrDefaultAsync(c => c.SolicitudViajeId == id);
    }

    public async Task<SolicitudViajes?> BuscarPorClienteId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursiones
            .FirstOrDefaultAsync(c => c.ClienteId == id);
    }

    public async Task<List<SolicitudViajes>> Listar(Expression<Func<SolicitudViajes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursiones
            .Include(x => x.Cliente)
            .Include(x => x.ListaDetalles)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
