using System;

namespace Marfrig.CompraGado.Domain.Entities
{
    public class FiltroCompraGado
    {
        public int PecuaristaId { get; set; }

        public Nullable<DateTime> DataDe { get; set; }

        public Nullable<DateTime> DataAte { get; set; }

        public int Pagina { get; set; }
    }
}
