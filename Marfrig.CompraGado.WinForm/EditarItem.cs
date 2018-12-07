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
    public partial class EditarItem : Form
    {
        private Models.CompraGadoItem _item;

        public EditarItem()
        {
            InitializeComponent();
        }

        public EditarItem(Models.CompraGadoItem item)
        {
            _item = item;
        }
    }
}
