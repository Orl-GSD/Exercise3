using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class Form1 : Form
    {

        private decimal _grandTotal = 0;

        public Form1()
        {            
            InitializeComponent();
            dgvTransaction.DefaultCellStyle.ForeColor = Color.Black;
            dgvTransaction.DefaultCellStyle.SelectionBackColor = dgvTransaction.DefaultCellStyle.BackColor;
            dgvTransaction.DefaultCellStyle.SelectionForeColor = dgvTransaction.DefaultCellStyle.ForeColor;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Product> menu = ProductData.GetMenu();

            foreach (var product in menu)
            {
                ProductCard card = new ProductCard();

                card.ItemName = product.Name;
                card.Price = product.Price;

                if (System.IO.File.Exists(product.ImagePath))
                    card.ProductImage = Image.FromFile(product.ImagePath);

                card.ProductClicked += HandleProductClicked;

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        public string ShowSizeSelectionPopup()
        {
            var result = MessageBox.Show(
                "Choose Cup Size:\n" +
                "Yes for Grande (+20.00),\n" +
                "No for Venti (+30.00),\n" +
                "Cancel for Regular",
                "Select Cup Size",
                MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Yes) return "Grande";
            if (result == DialogResult.No) return "Venti";
            return "Regular";
        }

        private void HandleProductClicked(object sender, EventArgs e)
        {
            ProductCard clickedCard = (ProductCard)sender;

            string size = ShowSizeSelectionPopup();

            decimal basePrice = clickedCard.Price;
            decimal addedPrice = 0;
            string displayName = clickedCard.ItemName;

            if (size == "Grande")
            {
                addedPrice = 20.00m;
                displayName = $"{clickedCard.ItemName} (Grande)";
            }
            else if (size == "Venti")
            {
                addedPrice = 30.00m;
                displayName = $"{clickedCard.ItemName} (Venti)";
            }

            decimal finalUnitPrice = basePrice + addedPrice;
            bool itemFound = false;

            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                if (row.Cells["colName"].Value?.ToString() == displayName)
                {
                    int currentQty = Convert.ToInt32(row.Cells["colQty"].Value);
                    int newQty = currentQty + 1;
                    row.Cells["colQty"].Value = newQty;
                    row.Cells["colTotal"].Value = newQty * finalUnitPrice;
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                dgvTransaction.Rows.Add(displayName, 1, finalUnitPrice, finalUnitPrice);
            }

            CalculateGrandTotal();
        }

        private void CalculateGrandTotal()
        {
            _grandTotal = 0;
            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                _grandTotal += Convert.ToDecimal(row.Cells["colTotal"].Value);
            }
            lbTotalAmount.Text = _grandTotal.ToString("C2");

            UpdateChange();
        }

        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            UpdateChange();
        }

        private void UpdateChange()
        {
            decimal tendered = decimal.TryParse(txtAmountTendered.Text, out tendered) ? tendered : 0;

            decimal change = tendered - _grandTotal;

            lbChange.Text = (tendered >= _grandTotal) ? change.ToString("C2") : "₱0.00";
        }

        private void btnAddNewTransaction_Click(object sender, EventArgs e)
        {
            dgvTransaction.Rows.Clear();

            _grandTotal = 0;
            lbTotalAmount.Text = "₱0.00";

            txtAmountTendered.Clear();
           
            lbChange.Text = "₱0.00";

            MessageBox.Show("New Transaction Started!");
        }

    }
}
