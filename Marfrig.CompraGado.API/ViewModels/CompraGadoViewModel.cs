using System;
using System.Collections.Generic;

namespace Marfrig.CompraGado.API.ViewModels
{
    public class CompraGadoViewModel
    {
        public CompraGadoViewModel()
        {
            this.CompraGadoItens = new List<CompraGadoItemViewModel>();
        }

        public int Id { get; set; }

        public DateTime DataEntrega { get; set; }

        public int PecuaristaId { get; set; }

        public List<CompraGadoItemViewModel> CompraGadoItens { get; set; }

        public PecuaristaViewModel Pecuarista { get; set; }
    }
}