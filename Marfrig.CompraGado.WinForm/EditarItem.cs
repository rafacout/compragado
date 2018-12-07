using Marfrig.CompraGado.WinForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            if (cmbProduto.SelectedValue == null)
            {
                MessageBox.Show("Selecione um Produto!");
                cmbProduto.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtQuantidade.Text) && txtQuantidade.Text == "0")
            {
                MessageBox.Show("Quantidade não pode ser zero");
                txtQuantidade.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtValorTotal.Text) && txtQuantidade.Text == "0")
            {
                MessageBox.Show("Valor total não pode ser zero");
                txtValorTotal.Focus();
                return;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProduto_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = (Animal)cmbProduto.SelectedItem;

            txtPreco.Text = item.Preco.ToString("F2", CultureInfo.InvariantCulture);

            calculaTotalItem();
        }

        private void calculaTotalItem()
        {
            decimal quantidade = 0, preco = 0;

            if (!String.IsNullOrEmpty(txtQuantidade.Text))
                quantidade = Convert.ToDecimal(txtQuantidade.Text, CultureInfo.InvariantCulture);

            if (!String.IsNullOrEmpty(txtPreco.Text))
                preco = Convert.ToDecimal(txtPreco.Text, CultureInfo.InvariantCulture);

            txtValorTotal.Text = (quantidade * preco).ToString("F2", CultureInfo.InvariantCulture);
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            calculaTotalItem();
        }
    }
}
