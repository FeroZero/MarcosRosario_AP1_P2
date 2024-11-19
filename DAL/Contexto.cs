using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcosRosario_AP1_P2.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Combos> Combos { get; set; }
		public DbSet<CombosDetalle> CombosDetalle { get; set; }
        public DbSet<Articulo> articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CombosDetalle>().HasData(new List<CombosDetalle>()
            {
                new CombosDetalle() {DetalleId = 1, ArticuloId = 1, Cantidad = 10, },
            });
        }
    }
}
