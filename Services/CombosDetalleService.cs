using MarcosRosario_AP1_P2.DAL;
using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarcosRosario_AP1_P2.Services
{
	public class CombosDetalleService(IDbContextFactory<Contexto> DbFactory)
	{
		public async Task<List<CombosDetalle>> Listar(Expression<Func<CombosDetalle, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.CombosDetalle
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
		}
	}
}
