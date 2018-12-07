using Marfrig.CompraGado.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public partial class EditarItem : Form
    {
        public Models.CompraGadoItem _item;

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

            List<Models.Animal> _animal = HttpUtil.GetAll<Models.Animal>(url);

            cmbProduto.DataSource = _animal;
            cmbProduto.DisplayMember = "Descricao";
            cmbProduto.ValueMember = "Id";
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

            _item.AnimalId = Convert.ToInt32(cmbProduto.SelectedValue);
            _item.Animal = (Animal)cmbProduto.SelectedItem;
            _item.Quantidade = Convert.ToDecimal(txtQuantidade.Text, CultureInfo.InvariantCulture);
            _item.ValorTotal = Convert.ToDecimal(txtValorTotal.Text, CultureInfo.InvariantCulture);

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
