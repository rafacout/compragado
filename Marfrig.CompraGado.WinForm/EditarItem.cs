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
            InitializeComponent();
        }

        private void EditarItem_Load(object sender, EventArgs e)
        {
            popularProduto();

            txtPreco.Text = _item.Animal.Preco.ToString();
            txtQuantidade.Text = _item.Quantidade.ToString();
            txtValorTotal.Text = _item.ValorTotal.ToString();
        }

        private void popularProduto()
        {
            string url = "http://localhost/Marfrig/api/animais";

            List<Models.Animal> _animal = new List<Models.Animal>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var fileJsonString = response.Result.Content.ReadAsStringAsync().Result;

                        _animal = JsonConvert.DeserializeObject<Models.Animal[]>(fileJsonString).ToList();

                        cmbProduto.DataSource = _animal;
                        cmbProduto.DisplayMember = "Descricao";
                        cmbProduto.ValueMember = "Id";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro");
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
