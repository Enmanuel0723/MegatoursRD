using MegatoursRD.Data;
using MegatoursRD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MegatoursRD.Services;

public class DestinosService(IDbContextFactory<ApplicationDbContext> DbFactory)
{
	public async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Destinos
							 .AnyAsync(c => c.DestinoId == id);
	}
	private async Task<bool> Insertar(Destinos destino)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		contexto.Destinos.Add(destino);
		return await contexto.SaveChangesAsync() > 0;
	}
	private async Task<bool> Modificar(Destinos destino)
	{
		await using var _context = await DbFactory.CreateDbContextAsync();
		_context.Destinos.Update(destino);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> AfectarCuposEnCarrito(List<Destinos> listaDestinosEnCarrito)
	{
		await using var _context = await DbFactory.CreateDbContextAsync();
		_context.Destinos.UpdateRange(listaDestinosEnCarrito);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Destinos destino)
	{
		if (!await Existe(destino.DestinoId))
			return await Insertar(destino);
		else
			return await Modificar(destino);
	}

	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();

		return await contexto.Destinos
			.Where(c => c.DestinoId == id)
			.ExecuteDeleteAsync() > 0;
	}

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
