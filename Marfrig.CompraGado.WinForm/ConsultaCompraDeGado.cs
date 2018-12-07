using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class ConsultaCompraDeGado : Form
    {
        public ConsultaCompraDeGado()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisarCompraGado();
        }

        private void pesquisarCompraGado()
        {
            string registrosPorpagina = txtRegistrosPorPagina.Text;
            string pagina = txtPagina.Text;
            string id = txtId.Text;
            string dataDe = Convert.ToDateTime(dtpDataDe.Text).ToString("MM/dd/yyyy");
            string dataAte = Convert.ToDateTime(dtpDataAte.Text).ToString("MM/dd/yyyy");
            string pecuaristaId = ((ComboBox)cmbPecuarista).SelectedValue.ToString();

            string url = "http://localhost/Marfrig/api/compragados";

            string filtro = "";

            if (String.IsNullOrEmpty(id))
            {
                filtro = String.Format("?RegistrosPorPagina={0}&pagina={1}&datade={2}&dateate={3}&pecuaristaid={4}",
                    registrosPorpagina, pagina, dataDe, dataAte, pecuaristaId);
            }
            else
            {
                filtro = String.Format("?id={0}", id);
            }

            List<Models.CompraGado> _comprasDeGado = HttpUtil.GetAll<Models.CompraGado>(url + filtro);

            dgCompraGado.DataSource = _comprasDeGado;
        }

        private void popularPecuarista()
        {
            string url = "http://localhost/Marfrig/api/pecuaristas";

            List<Models.Pecuarista> _pecuaristas = HttpUtil.GetAll<Models.Pecuarista>(url);

            cmbPecuarista.DataSource = _pecuaristas;
            cmbPecuarista.DisplayMember = "Nome";
            cmbPecuarista.ValueMember = "Id";
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(txtPagina.Text);
            int registrosPorPagina = Convert.ToInt32(txtRegistrosPorPagina.Text);

            if (registrosPorPagina == dgCompraGado.RowCount)
                txtPagina.Text = (pagina + 1).ToString();

            pesquisarCompraGado();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(txtPagina.Text);

            if (pagina > 1)
                txtPagina.Text = (pagina - 1).ToString();

            pesquisarCompraGado();
        }

        private void ConsultaCompraDeGado_Load(object sender, EventArgs e)
        {
            popularPecuarista();
            pesquisarCompraGado();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            EditarCompraDeGado form = new EditarCompraDeGado(new Models.CompraGado() {
                Id = 0,
                DataEntrega = DateTime.Now.AddDays(7)
            });

            var result = form.ShowDialog();

            pesquisarCompraGado();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgCompraGado.SelectedRows.Count > 0)
            {
                var item = (Models.CompraGado)dgCompraGado.SelectedRows[0].DataBoundItem;

                EditarCompraDeGado form = new EditarCompraDeGado(item);

                form.ShowDialog();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgCompraGado.SelectedRows.Count > 0)
            {
                Models.CompraGado item = (Models.CompraGado)dgCompraGado.SelectedRows[0].DataBoundItem;

                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir a Compra?", "Atenção", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var item = (Models.CompraGado)dgCompraGado.SelectedRows[0].DataBoundItem;

            ImprimirCompra form = new ImprimirCompra(item);

            form.ShowDialog();
        }
    }
}
