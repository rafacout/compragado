using Marfrig.CompraGado.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Marfrig.CompraGado.Data.EntityTypeConfiguration
{
    internal class PecuaristaTypeConfiguration : EntityTypeConfiguration<Pecuarista>
    {
        public PecuaristaTypeConfiguration()
        {
            this.ToTable("Pecurista");

            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}