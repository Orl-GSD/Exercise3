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
    public partial class ProductCard : UserControl
    {
        private string _productName;
        private decimal _price;
        private Image _productImage;

        public event EventHandler ProductClicked;

        public ProductCard()
        {
            InitializeComponent();
            WireUpEvents();
        }
        private void WireUpEvents()
        {
            this.Click += (s, e) => OnProductClicked(e);

            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => OnProductClicked(e);
                foreach (Control child in c.Controls)
                {
                    child.Click += (s, e) => OnProductClicked(e);
                }
            }
        }
        protected virtual void OnProductClicked(EventArgs e)
        {
            ProductClicked?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ItemName
        {
            get => _productName;
            set { _productName = value; lbProductName.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                lbPrice.Text = value.ToString("C2");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image ProductImage
        {
            get => _productImage;
            set
            {
                _productImage = value;
                pbProductImage.BackgroundImage = value;
                pbProductImage.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
