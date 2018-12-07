using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class EditarCompraDeGado : Form
    {
        public Models.CompraGado _compraGado;

        public EditarCompraDeGado()
        {
            InitializeComponent();
        }

        public EditarCompraDeGado(Models.CompraGado compra)
        {
            _compraGado = compra;
            InitializeComponent();
        }

        private void CompraDeGado_Load(object sender, EventArgs e)
        {
            popularPecuarista();

            txtId.Text = _compraGado.Id.ToString();
            dtpDataEntrega.Value = _compraGado.DataEntrega;
            cmbPecuarista.SelectedValue = _compraGado.PecuaristaId;
        }

        private void popularGrid()
        {
            dgItens.DataSource = _compraGado.CompraGadoItens;
        }

        private void popularPecuarista()
        {
            string url = "http://localhost/Marfrig/api/pecuaristas";

            List<Models.Pecuarista> _pecuaristas = HttpUtil.GetAll<Models.Pecuarista>(url) ;

            cmbPecuarista.DataSource = _pecuaristas;
            cmbPecuarista.DisplayMember = "Nome";
            cmbPecuarista.ValueMember = "Id";
        }

        private void ctnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbPecuarista.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Pecuarista!");
                cmbPecuarista.Focus();
                return;
            }

            if (dgItens.Rows.Count == 0)
            {
                MessageBox.Show("Adicione um Produto!");
                return;
            }

            if (_compraGado.Id == 0)
            {
                //chamar o post
            }
            else
            {
                //chamar o put
            }

            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            EditarItem form = new EditarItem(new Models.CompraGadoItem() { Id = 0 });

            var result = form.ShowDialog();

            _compraGado.CompraGadoItens.Add(form._item);

            popularGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgItens.SelectedRows.Count > 0)
            {
                var item = (Models.CompraGadoItem)dgItens.SelectedRows[0].DataBoundItem;

                EditarItem form = new EditarItem(item);

                var result = form.ShowDialog();

                _compraGado.CompraGadoItens.Add(form._item);

                popularGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgItens.SelectedRows.Count > 0)
            {
                Models.CompraGadoItem item = (Models.CompraGadoItem)dgItens.SelectedRows[0].DataBoundItem;

                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o Item?", "Atenção", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
            }
        }
    }
}
