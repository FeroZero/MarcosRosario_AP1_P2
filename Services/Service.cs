using MarcosRosario_AP1_P2.DAL;
using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarcosRosario_AP1_P2.Services
{
	public class Service(IDbContextFactory<Contexto> DbFactory)
	{

		private async Task<bool> Existe(int id)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return true;
        }

		private async Task<bool> Insertar(Combos registro)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return true;
        }

		private async Task<bool> Modificar(Combos registro)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return true;
		}

		public async Task<bool> Eliminar(int id)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return true;
        }

		public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> registro)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return null;
        }


		public async Task<Combos?> Buscar(int id)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return null;
        }
		public async Task<bool> Guardar(Combos registro)
		{
			return true;
		}
	}
}
