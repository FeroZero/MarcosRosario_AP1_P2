using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcosRosario_AP1_P2.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Combos> Registro { get; set; }
    }
}
