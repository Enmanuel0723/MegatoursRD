using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class SolicitudViajesDetalleService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<List<SolicitudViajesDetalle>> Listar(Expression<Func<SolicitudViajesDetalle, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.SolicitudExcursionesDetalle
            .Include(x => x.SolicitudExcursion)
            .Include(x => x.Destino)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
