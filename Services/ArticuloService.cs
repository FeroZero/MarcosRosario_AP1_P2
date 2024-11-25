using MarcosRosario_AP1_P2.DAL;
using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarcosRosario_AP1_P2.Services
{
	public class ArticuloService(IDbContextFactory<Contexto> DbFactory)
	{

		private async Task<bool> Existe(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Articulos.AnyAsync(c => c.ArticuloId > 0);
		}

		private async Task<bool> Insertar(Articulos articulos)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Articulos.Add(articulos);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Modificar(Articulos articulos)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Articulos.Update(articulos);
			return await contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Eliminar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Articulos
			.Where(c => c.ArticuloId > 0)
			.ExecuteDeleteAsync() > 0;
		}

		public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Articulos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
		}


		public async Task<Articulos?> Buscar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Articulos
			   .AsNoTracking()
		   .FirstOrDefaultAsync(c => c.ArticuloId == id);
		}
		public async Task<bool> Guardar(Articulos articulos)
		{
			if (!await Existe(articulos.ArticuloId))
				return await Insertar(articulos);
			else
				return await Modificar(articulos);
		}
	}
}
