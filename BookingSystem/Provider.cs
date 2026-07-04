using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Provider : Person
    {
        private List<Product> _products = new List<Product>();

        public List<Product> Products
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

        private string _service;
        public string Service
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value;
            }
        }

    }



}
