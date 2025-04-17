using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GuiasService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
    public async Task<Guias?> Buscar(int? id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Guias
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.GuiaId == id);
    }

    public async Task<List<Guias>> Listar(Expression<Func<Guias, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Guias
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}