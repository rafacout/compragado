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
            string url = "http://localhost/Marfrig/api/compragados";

            List<Models.CompraGado> _comprasDeGado = new List<Models.CompraGado>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var fileJsonString = response.Result.Content.ReadAsStringAsync().Result;

                        dgCompraGado.DataSource = JsonConvert.DeserializeObject<Models.CompraGado[]>(fileJsonString).ToList();
                    }
                }
            }
        }
    }
}
