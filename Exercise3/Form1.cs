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

        private string _productName;
        private decimal _price;

        public Form1()
        {            
            InitializeComponent();
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

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void textBoxWithLabel1_Load(object sender, EventArgs e)
        {

        }

        private void productCard1_Load(object sender, EventArgs e)
        {

        }

        private void productCard1_Load_1(object sender, EventArgs e)
        {

        }

    }
}
