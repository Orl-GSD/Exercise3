using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
    public static class ProductData
    {
        public static List<Product> GetMenu()
        {
            return new List<Product>
        {
            new Product { Name = "Creamy Pure Matcha Latte", Price = 180.00m, ImagePath = "images/matcha_latte.jpeg" },
            new Product { Name = "XOXO Frappuccino", Price = 150.00m, ImagePath = "images/xoxo_frappucino.jpeg" },
            new Product { Name = "Strawberry Açaí with Lemonade", Price = 160.00m, ImagePath = "images/strawberry_acai.jpeg" },
            new Product { Name = "Pink Drink with Strawberry Açaí", Price = 165.00m, ImagePath = "images/pink_drink.jpeg" },
            new Product { Name = "Dragon Drink with Mango Dragonfruit", Price = 170.00m, ImagePath = "images/dragon_drink.jpeg" },
            new Product { Name = "Strawberries Cream Frappucino", Price = 175.00m, ImagePath = "images/strawberries_cream.jpg" },
            new Product { Name = "Chocolate Chip Cream Frappucino", Price = 180.00m, ImagePath = "images/chocolate_chip.jpg" },
            new Product { Name = "Dark Caramel Coffee Frappucino", Price = 170.00m, ImagePath = "images/dark_caramel_frappucino.jpg" },
        };
        }
    }
}
