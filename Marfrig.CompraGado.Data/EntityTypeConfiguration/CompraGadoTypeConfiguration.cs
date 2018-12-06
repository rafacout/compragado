using System.Data.Entity.ModelConfiguration;

namespace Marfrig.CompraGado.Data.EntityTypeConfiguration
{
    internal class CompraGadoTypeConfiguration : EntityTypeConfiguration<Domain.Entities.CompraGado>
    {
        public CompraGadoTypeConfiguration()
        {
            this.ToTable("CompraGado");

            HasKey(c => c.Id);

            Property(c => c.PecuaristaId)
                .IsRequired();

            Property(c => c.DataEntrega)
                .IsRequired();

            Property(c => c.ValorTotal)
                .IsRequired();
        }
    }
}