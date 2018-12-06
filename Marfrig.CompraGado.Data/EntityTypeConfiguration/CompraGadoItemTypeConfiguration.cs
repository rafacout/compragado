using System.Data.Entity.ModelConfiguration;

namespace Marfrig.CompraGado.Data.EntityTypeConfiguration
{
    internal class CompraGadoItemTypeConfiguration : EntityTypeConfiguration<Domain.Entities.CompraGadoItem>
    {
        public CompraGadoItemTypeConfiguration()
        {
            this.ToTable("CompraGadoItem");

            HasKey(c => c.Id);

            Property(c => c.CompraGadoId)
                .IsRequired();

            Property(c => c.AnimalId)
                .IsRequired();

            Property(c => c.Quantidade)
                .IsRequired();

            //Configuracao do relacionamento
            HasRequired(p => p.CompraGado)
                .WithMany(i => i.CompraGadoItens)
                .HasForeignKey(p => p.CompraGadoId);
        }
    }
}