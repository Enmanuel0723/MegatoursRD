using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class ViajesService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Viajes
                             .AnyAsync(c => c.ViajeId == id);
    }

    private async Task<bool> Insertar(Viajes viaje)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        contexto.Viajes.Add(viaje);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Viajes viaje)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();

        _context.Viajes.Update(viaje);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Viajes viaje)
    {
        if (!await Existe(viaje.ViajeId))
            return await Insertar(viaje);
        else
            return await Modificar(viaje);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Viajes
            .Where(c => c.ViajeId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Viajes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Viajes
            .FirstOrDefaultAsync(c => c.ViajeId == id);
    }

    public async Task<Viajes?> BuscarPorSolicitudId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Viajes
            .FirstOrDefaultAsync(c => c.SolicitudViajeId == id);
    }

    public async Task<List<Viajes>> Listar(Expression<Func<Viajes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Viajes
            .Include(x => x.Guia)
            .Include(x => x.SolicitudViaje)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
