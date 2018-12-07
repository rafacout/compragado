using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            string filters = "";

            if (String.IsNullOrEmpty(id))
            {
                filters = String.Format("?RegistrosPorPagina={0}&pagina={1}&datade={2}&dateate={3}&pecuaristaid={4}",
                    registrosPorpagina, pagina, dataDe, dataAte, pecuaristaId);
            }
            else
            {
                filters = String.Format("?id={0}", id);
            }


            List<Models.CompraGado> _comprasDeGado = new List<Models.CompraGado>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url + filters))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var fileJsonString = response.Result.Content.ReadAsStringAsync().Result;

                        dgCompraGado.DataSource = JsonConvert.DeserializeObject<Models.CompraGado[]>(fileJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro");
                    }
                }
            }
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
            var teste = new Models.CompraGado()
            {
                Id = 1,
                DataEntrega = DateTime.Now,
                PecuaristaId = 2,
                ValorTotal = (Decimal)1000.99
            };

            teste.CompraGadoItens.Add(new Models.CompraGadoItem()
            {
                Id = 1,
                Quantidade = 2
            });

            CompraDeGado form = new CompraDeGado(teste);

            form.ShowDialog();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var item = (Models.CompraGado)dgCompraGado.SelectedRows[0].DataBoundItem;

            CompraDeGado form = new CompraDeGado(item);

            form.ShowDialog();
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
