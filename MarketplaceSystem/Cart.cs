using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Cart
    {
        private List<Product> _products = new List<Product>();

        List<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }

        public void AddProduct(Product product){ 
            Products.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
