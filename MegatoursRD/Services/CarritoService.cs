using MegatoursRD.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MegatoursRD.Services;

public class CarritoService(IDbContextFactory<ApplicationDbContext> dbFactory, IHttpContextAccessor httpContextAccessor)
{
	private readonly IDbContextFactory<ApplicationDbContext> _dbFactory = dbFactory;
	private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

	// Obtener el ClienteId del usuario autenticado
	private int? ObtenerClienteId(ApplicationDbContext context)
	{
		var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
		if (userId == null) return null;

		var cliente = context.Clientes.FirstOrDefault(c => c.AplicationUserId == userId);
		return cliente?.ClienteId;
	}

	// Obtener el carrito del cliente autenticado
	private string ObtenerCarritoAnonimoId()
	{
		var session = _httpContextAccessor.HttpContext?.Session;
		if (session == null) return string.Empty;

		const string key = "CarritoAnonimoId";

		if (string.IsNullOrEmpty(session.GetString(key)))
		{
			session.SetString(key, Guid.NewGuid().ToString());
		}

		return session.GetString(key)!;
	}

	public async Task<Carrito> ObtenerCarritoAsync()
	{
		await using var context = await _dbFactory.CreateDbContextAsync();

		var clienteId = ObtenerClienteId(context);

		if (clienteId != null)
		{
			var carrito = await context.Carritos
				.Include(c => c.Detalles)
				.ThenInclude(d => d.Destino)
				.FirstOrDefaultAsync(c => c.ClienteId == clienteId);

			if (carrito != null) return carrito;

			// Crear carrito nuevo para cliente autenticado
			var nuevoCarrito = new Carrito { ClienteId = clienteId };
			context.Carritos.Add(nuevoCarrito);
			await context.SaveChangesAsync();
			return nuevoCarrito;
		}
		else
		{
			var anonId = ObtenerCarritoAnonimoId();

			var carrito = await context.Carritos
				.Include(c => c.Detalles)
				.ThenInclude(d => d.Destino)
				.FirstOrDefaultAsync(c => c.SesionAnonimaId == anonId);

			if (carrito != null) return carrito;

			// Crear carrito nuevo anónimo
			var nuevoCarrito = new Carrito { SesionAnonimaId = anonId };
			context.Carritos.Add(nuevoCarrito);
			await context.SaveChangesAsync();
			return nuevoCarrito;
		}
	}

	public async Task MigrarCarritoAnonimoAlClienteAsync()
	{
		await using var context = await _dbFactory.CreateDbContextAsync();

		var clienteId = ObtenerClienteId(context);
		if (clienteId == null) return;

		var anonId = ObtenerCarritoAnonimoId();

		var carritoAnonimo = await context.Carritos
			.Include(c => c.Detalles)
			.FirstOrDefaultAsync(c => c.SesionAnonimaId == anonId);

		if (carritoAnonimo == null || !carritoAnonimo.Detalles.Any()) return;

		var carritoCliente = await context.Carritos
			.Include(c => c.Detalles)
			.FirstOrDefaultAsync(c => c.ClienteId == clienteId);

		if (carritoCliente == null)
		{
			carritoAnonimo.ClienteId = clienteId;
			carritoAnonimo.SesionAnonimaId = null;
		}
		else
		{
			// Merge detalles
			foreach (var detalle in carritoAnonimo.Detalles)
			{
				if (!carritoCliente.Detalles.Any(d => d.DestinoId == detalle.DestinoId))
					carritoCliente.Detalles.Add(detalle);
			}

			context.Carritos.Remove(carritoAnonimo);
		}

		await context.SaveChangesAsync();
	}

	// Agregar un destino al carrito
	public async Task<bool> AgregarAlCarritoAsync(int destinoId, int cantAdultos, int cantNinos, double precioAdultos = 1350.0, double precioNinos = 750.0)
	{
		await using var contexto = await _dbFactory.CreateDbContextAsync();

		var clienteId = ObtenerClienteId(contexto);

		Carrito? carrito;

		if (clienteId != null)
		{
			// Usuario autenticado
			carrito = await contexto.Carritos
				.Include(c => c.Detalles)
				.FirstOrDefaultAsync(c => c.ClienteId == clienteId);

			if (carrito == null)
			{
				carrito = new Carrito { ClienteId = clienteId.Value };
				contexto.Carritos.Add(carrito);
				await contexto.SaveChangesAsync(); // Crear CarritoId
			}
		}
		else
		{
			// Usuario anónimo
			var anonId = ObtenerCarritoAnonimoId();

			carrito = await contexto.Carritos
				.Include(c => c.Detalles)
				.FirstOrDefaultAsync(c => c.SesionAnonimaId == anonId);

			if (carrito == null)
			{
				carrito = new Carrito { SesionAnonimaId = anonId };
				contexto.Carritos.Add(carrito);
				await contexto.SaveChangesAsync(); // Crear CarritoId
			}
		}

		// Ya existe el carrito (autenticado o anónimo), ahora agregamos el destino
		var detalleExistente = carrito.Detalles.FirstOrDefault(d => d.DestinoId == destinoId);
		if (detalleExistente != null)
		{
			detalleExistente.CantAdultos += cantAdultos;
			detalleExistente.CantNinos += cantNinos;
		}
		else
		{
			carrito.Detalles.Add(new CarritoDetalle
			{
				DestinoId = destinoId,
				CantAdultos = cantAdultos,
				CantNinos = cantNinos,
				PrecioAdultos = precioAdultos,
				PrecioNinos = precioNinos
			});
		}

		return await contexto.SaveChangesAsync() > 0;
	}


	// Eliminar un detalle del carrito
	public async Task<bool> RemoverDelCarritoAsync(int detalleId)
	{
		await using var contexto = await _dbFactory.CreateDbContextAsync();

		var detalle = await contexto.CarritoDetalles.FindAsync(detalleId);
		if (detalle != null)
		{
			contexto.CarritoDetalles.Remove(detalle);
			return await contexto.SaveChangesAsync() > 0;
		}

		return false;
	}

	// Vaciar el carrito completo
	public async Task<bool> VaciarCarritoAsync()
	{
		await using var contexto = await _dbFactory.CreateDbContextAsync();

		var carrito = await ObtenerCarritoAsync();
		if (carrito != null)
		{
			contexto.CarritoDetalles.RemoveRange(carrito.Detalles);
			return await contexto.SaveChangesAsync() > 0;
		}

		return false;
	}

	// Comprobar si el carrito existe
	public async Task<bool> ExisteCarritoAsync()
	{
		await using var contexto = await _dbFactory.CreateDbContextAsync();

		var clienteId = ObtenerClienteId(contexto);
		if (clienteId == null) return false;

		return await contexto.Carritos.AnyAsync(c => c.ClienteId == clienteId);
	}
}
