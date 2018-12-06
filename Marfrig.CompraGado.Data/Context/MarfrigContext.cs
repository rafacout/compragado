using Marfrig.CompraGado.Data.EntityTypeConfiguration;
using Marfrig.CompraGado.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Marfrig.CompraGado.Data.Context
{
    public class MarfrigContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }

        public DbSet<Pecuarista> Pecuaristas { get; set; }

        public DbSet<Domain.Entities.CompraGado> CompraGados { get; set; }

        public DbSet<CompraGadoItem> CompraGadoItens { get; set; }


        public MarfrigContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AnimalTypeConfiguration());
            modelBuilder.Configurations.Add(new PecuaristaTypeConfiguration());
            modelBuilder.Configurations.Add(new CompraGadoTypeConfiguration());
            modelBuilder.Configurations.Add(new CompraGadoItemTypeConfiguration());
        }

    }
}
