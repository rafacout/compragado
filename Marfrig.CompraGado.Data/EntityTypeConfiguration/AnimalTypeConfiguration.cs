using Marfrig.CompraGado.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Marfrig.CompraGado.Data.EntityTypeConfiguration
{
    internal class AnimalTypeConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalTypeConfiguration()
        {
            this.ToTable("Animal");

            HasKey(c => c.Id);

            Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(c => c.Preco)
                .IsRequired();

        }
    }
}