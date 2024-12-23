﻿using MarcosRosario_AP1_P2.DAL;
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

		private async Task<bool> Insertar(Registro registro)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return true;
        }

		private async Task<bool> Modificar(Registro registro)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return true;
		}

		public async Task<bool> Eliminar(int id)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return true;
        }

		public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> registro)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return null;
        }


		public async Task<Registro?> Buscar(int id)
		{
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return null;
        }
		public async Task<bool> Guardar(Registro registro)
		{
			return true;
		}
	}
}
