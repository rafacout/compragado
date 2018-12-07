using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class ImprimirCompra : Form
    {
        private Models.CompraGado _compraGado;

        public ImprimirCompra()
        {
            InitializeComponent();
        }

        public ImprimirCompra(Models.CompraGado compra)
        {
            _compraGado = compra;
            InitializeComponent();
        }

        private void ImprimirCompra_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
