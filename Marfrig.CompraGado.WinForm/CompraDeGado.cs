using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class CompraDeGado : Form
    {
        private Models.CompraGado _compraGado;

        public CompraDeGado()
        {
            InitializeComponent();
        }

        public CompraDeGado(Models.CompraGado compra)
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
    }
}
