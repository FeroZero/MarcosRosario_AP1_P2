using MarcosRosario_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcosRosario_AP1_P2.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Combos> Combos { get; set; }
		public DbSet<CombosDetalle> CombosDetalle { get; set; }
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
            {
                new () {ArticuloId = 1, Descripcion = "CPU"},
                new () {ArticuloId = 2, Descripcion = "GPU"},
                new () {ArticuloId = 3, Descripcion = "Power"}
            });
        }
    }
}
