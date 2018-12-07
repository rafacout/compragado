using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class EditarCompraDeGado : Form
    {
        private Models.CompraGado _compraGado;

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

            dgItens.DataSource = _compraGado.CompraGadoItens;
        }

        private void popularPecuarista()
        {
            string url = "http://localhost/Marfrig/api/pecuaristas";

            List<Models.Pecuarista> _pecuaristas = new List<Models.Pecuarista>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var fileJsonString = response.Result.Content.ReadAsStringAsync().Result;

                        _pecuaristas = JsonConvert.DeserializeObject<Models.Pecuarista[]>(fileJsonString).ToList();

                        cmbPecuarista.DataSource = _pecuaristas;
                        cmbPecuarista.DisplayMember = "Nome";
                        cmbPecuarista.ValueMember = "Id";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro");
                    }
                }
            }
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

            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            EditarItem form = new EditarItem(new Models.CompraGadoItem() { Id = 0 });

            form.ShowDialog();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgItens.SelectedRows.Count > 0)
            {
                var item = (Models.CompraGadoItem)dgItens.SelectedRows[0].DataBoundItem;

                EditarItem form = new EditarItem(item);

                form.ShowDialog();
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
