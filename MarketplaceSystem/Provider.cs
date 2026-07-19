using BookingSystem;
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

        //Start provider sign up function
        public static Provider SignUp()
        {
            Provider provider = new Provider();
            provider.ReadCommonInfoForSignUp();
            Console.WriteLine("enter your service");
            provider.Service = InputHelper.GetStringValue();
            return provider;

        }
        //End provider sign up function

    }



}
