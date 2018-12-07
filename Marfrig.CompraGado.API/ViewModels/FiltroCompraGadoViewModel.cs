using System;

namespace Marfrig.CompraGado.API.ViewModels
{
    public class FiltroCompraGadoViewModel
    {
        public int PecuaristaId { get; set; }

        public Nullable<DateTime> DataDe { get; set; }

        public Nullable<DateTime> DataAte { get; set; }

        public int Pagina { get; set; }

        public int RegistrosPorPagina { get; set; }
    }
}