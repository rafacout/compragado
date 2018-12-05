
namespace Marfrig.CompraGado.Domain.Entities
{
    public class CompraGadoItem
    {
        public int Id { get; set; }

        public int CompraGadoId { get; set; }

        public float Quantidade { get; set; }

        public int AnimalId { get; set; }

        public CompraGado CompraGado { get; set; }

        public Animal Animal { get; set; }

    }
}
