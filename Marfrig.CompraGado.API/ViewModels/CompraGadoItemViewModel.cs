namespace Marfrig.CompraGado.API.ViewModels
{
    public class CompraGadoItemViewModel
    {
        public int Id { get; set; }

        public int CompraGadoId { get; set; }

        public decimal Quantidade { get; set; }

        public int AnimalId { get; set; }

        public CompraGadoViewModel CompraGado { get; set; }

        public AnimalViewModel Animal { get; set; }
    }
}