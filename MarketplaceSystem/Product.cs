using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Product
    {
        private string _name;
        private string _description;
        private string _price;
        private string _stock;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }

        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }

        }
        public string Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
            }

        }

    }
}
