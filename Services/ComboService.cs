using MarcosRosario_AP1_P2.DAL;
using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarcosRosario_AP1_P2.Services;

public class ComboService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task AfectarArticulo(CombosDetalle[] detalle, bool resta = true)
    {
        foreach (var item in detalle)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var articulo = await contexto.Articulos.SingleAsync(p => p.ArticuloId == item.ArticuloId);
            if (resta)
            {
                articulo.Existencia -= item.Cantidad;
            }
            else
            {
                articulo.Existencia += item.Cantidad;
            }
        }
    }
    private async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Combos.AnyAsync(c => c.ComboId > 0);
	}

	private async Task<bool> Insertar(Combos registro)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Combos.Add(registro);
		await AfectarArticulo(registro.CombosDetalle.ToArray());
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Combos registro)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Update(registro);
		await AfectarArticulo(registro.CombosDetalle.ToArray());
		var modificado = await contexto.SaveChangesAsync() > 0;
		contexto.Entry(registro).State = EntityState.Modified;
		return modificado;
	}

	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Combos
		.Where(c => c.ComboId > 0)
		.ExecuteDeleteAsync() > 0;
	}

	public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Combos
		.Include(cs => cs.CombosDetalle)
		.AsNoTracking()
		.Where(criterio)
		.ToListAsync();
	}


	public async Task<Combos?> Buscar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Combos
		.Include(cs => cs.CombosDetalle)
		.FirstOrDefaultAsync(c => c.ComboId == id);
	}
	public async Task<bool> Guardar(Combos combos)
	{
		if (!await Existe(combos.ComboId))
			return await Insertar(combos);
		else
			return await Modificar(combos);
	}
}
