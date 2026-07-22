using MarketplaceSystem;
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

        // Start provider program
        public static void ProviderProgram(List<Provider> providers)
        {
            bool isRuning = true;
            while (isRuning)
            {

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Provider Menu :");
                    Console.WriteLine("1 Login");
                    Console.WriteLine("2 Sign up");
                    Console.WriteLine("3 Back to main menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    Provider provider;

                    switch (optionNumber)
                    {
                        case 1:
                            provider = Login(providers);
                            if (provider != null)
                            {
                                ProviderTools(provider);
                            }
                            else
                            {
                                Console.WriteLine("we couldn't find you ! please sign up first.");
                            }

                            break;
                        case 2:
                            provider = Provider.SignUp();
                            providers.Add(provider);
                            ProviderTools(provider);
                            break;
                        //case 3:
                        //    //ShowProviderList(providers);
                        //    //ShowAdminList(admins);
                        //break;
                        case 3:
                            isRuning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice please try again");
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("please enter numbers only");
                }
            }
        }
        // End provider program

        // Start provider tools
        private static void ProviderTools(Provider provider)
        {
            Console.WriteLine($"Hi {provider.FirstName} {provider.LastName}");

            bool isRuning = true;
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Provider Tools :");
                    Console.WriteLine("1 Show products");
                    Console.WriteLine("2 Add product");
                    Console.WriteLine("3 Delete product");
                    Console.WriteLine("4 Back to provider menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    switch (optionNumber)
                    {
                        case 1:

                            provider.ShowProducts();
                            break;
                        case 2:
                            provider.AddProduct();
                            break;
                        case 3:
                            bool hasProductDeleted = DeleteProduct(provider);
                            if (hasProductDeleted)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("product removed successfully.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("we couldn't find the prouduct!.");
                            }
                            break;
                        case 4:
                            isRuning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice please try again");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("please enter numbers only");
                }
            }
        }
        // End provider tools 

        //Start provider sign up function
        private static Provider SignUp()
        {
            Provider provider = new Provider();
            provider.ReadCommonInfoForSignUp();
            Console.WriteLine("enter your service");
            provider.Service = InputHelper.GetStringValue();
            return provider;

        }
        //End provider sign up function
        
        //Start provider ShowProducts function
        public void ShowProducts()
        {
            foreach (Product product in Products)
            {
                Console.WriteLine($"product info: name: {product.Name} , description: {product.Description} , price: {product.Price} , stock: {product.Stock}");
            }
        }
        //End provider ShowProducts function

        //Start add product
        private void AddProduct()
        {
            Console.WriteLine("please enter the name of product :");
            string name = InputHelper.GetStringValue();
            Console.WriteLine("please enter the description of product :");
            string desciption = InputHelper.GetStringValue();
            Console.WriteLine("please enter the price of product :");
            string price = InputHelper.GetStringValue();
            Console.WriteLine("please enter the stock of product :");
            string stock = InputHelper.GetStringValue();

            Products.Add(new Product
            {
                Name = name,
                Description = desciption,
                Price = price,
                Stock = stock
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("product added successfully");
            Console.ResetColor();
        }
        //End add product

        //Start delete product function
        private static bool DeleteProduct(Provider provider)
        {
            Console.WriteLine("please enter the name of the product you want to remove:");
            string name = InputHelper.GetStringValue();

            for (int i = 0; i < provider.Products.Count; i++)
            {
                if (provider.Products[i].Name == name)
                {
                    provider.Products.RemoveAt(i);

                    return true;

                }
            }

            return false;



        }
        //End add product function

    }



}
