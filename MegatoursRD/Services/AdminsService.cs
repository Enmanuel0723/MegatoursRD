using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class AdminsService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
	public async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Admins
							 .AnyAsync(c => c.AdminId == id);
	}

	private async Task<bool> Insertar(Admins admin)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		contexto.Admins.Add(admin);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Admins admin)
	{
		await using var _context = await DbFactory.CreateDbContextAsync();
		_context.Admins.Update(admin);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Admins admin)
	{
		if (!await Existe(admin.AdminId))
			return await Insertar(admin);
		else
			return await Modificar(admin);
	}

	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Admins
			.Where(c => c.AdminId == id)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Admins?> Buscar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Admins
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.AdminId == id);
	}

	public async Task<ApplicationUser?> BuscarPorUsuarioId(string id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Users
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<List<Admins>> Listar(Expression<Func<Admins, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Admins
			.Include(x => x.Usuario)
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}

	public async Task<Admins?> BuscarNombres(string nombre)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Admins
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Nombre == nombre);
	}
}
