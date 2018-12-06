using System;
using System.Collections.Generic;

namespace Marfrig.CompraGado.WinForm.Models
{
    public class CompraGado
    {
        public CompraGado()
        {
            this.CompraGadoItens = new List<CompraGadoItem>();
        }

        public int Id { get; set; }

        public DateTime DataEntrega { get; set; }

        public int PecuaristaId { get; set; }

        public List<CompraGadoItem> CompraGadoItens { get; set; }

        public Pecuarista Pecuarista { get; set; }
    }
}