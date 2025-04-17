using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class DestinosService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<Destinos>> Listar(Expression<Func<Destinos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Destinos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Destinos> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return contexto.Destinos
            .FirstOrDefault(x => x.DestinoId == id);
    }

    public async Task AfectarCupos(string[] ciudades, SolicitudViajes solicitud)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var destinos = await contexto.Destinos
                                        .Where(d => ciudades.Contains(d.Ciudad))
                                        .ToListAsync();

        foreach (var detalle in solicitud.ListaDetalles)
        {
            var destino = destinos.FirstOrDefault(x => x.Ciudad == detalle.Ciudad);
            if (destino != null)
            {
                if (detalle.CantNinos > 0)
                    destino.Cupos -= detalle.CantNinos;
                if (detalle.CantAdultos > 0)
                    destino.Cupos -= detalle.CantAdultos;

                contexto.Destinos.Update(destino);
            }
        }
        await contexto.SaveChangesAsync();
    }
}
