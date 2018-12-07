namespace Marfrig.CompraGado.WinForm.Models
{
    public class CompraGadoItem
    {
        public CompraGadoItem()
        {
            this.Animal = new Animal();
        }

        public int Id { get; set; }

        public int CompraGadoId { get; set; }

        public decimal Quantidade { get; set; }

        public int AnimalId { get; set; }

        public decimal ValorTotal { get; set; }

        public Animal Animal { get; set; }
    }
}