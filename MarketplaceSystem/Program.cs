using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start Temporary database 
            List<User> users = new List<User>();
            List<Provider> providers = new List<Provider>();
            List<Admin> admins = new List<Admin>();
            //End Temporary database 

            

            //ProviderProgram(providers);

            MainMenu(users, providers, admins);
        }
        //Start MainMenu function
        public static void MainMenu(List<User> users, List<Provider> providers, List<Admin> admins)
        {
            bool isRuning = true;

            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Determine your role");
                    Console.WriteLine("1 User");
                    Console.WriteLine("2 Provider");
                    Console.WriteLine("3 Admin");
                    Console.WriteLine("4 Exit");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    switch (optionNumber)
                    {
                        case 1:
                            UserProgram(users, providers);
                            break;
                        case 2:
                            ProviderProgram(providers);
                            break;
                        case 3:
                            AdminProgram(admins, providers, users);
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
        //End MainMenu function

        // Start user program
        public static void UserProgram(List<User> users, List<Provider> providers)
        {
            bool isRuning = true;
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("User Menu :");
                    Console.WriteLine("1 Login");
                    Console.WriteLine("2 Sign up");
                    Console.WriteLine("3 Back to main menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    User user;


                    switch (optionNumber)
                    {
                        case 1:
                            user = UserLogin(users);
                            if (user != null)
                            {
                                UserTools(user, providers);
                            }
                            else
                            {
                                Console.WriteLine("we couldn't find you ! please sign up first.");
                            }
                            break;
                        case 2:
                            user = UserSignUp();
                            users.Add(user);
                            UserTools(user, providers);
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
        // End user program

        //Start user tools function
        public static void UserTools(User user, List<Provider> providers)
        {

            Console.WriteLine($"Hi {user.FirstName} {user.LastName}");

            bool isRuning = true;
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("User Tools :");
                    Console.WriteLine("1 Show the products of providers");
                    Console.WriteLine("2 Back to user menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    switch (optionNumber)
                    {
                        case 1:
                            ShowProductsOfAllProviders(providers);
                            break;
                        case 2:
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
        //End user tools function

        //Start show products of all providers
        public static void ShowProductsOfAllProviders(List<Provider> providers)
        {
            foreach (Provider provider in providers)
            {
                Console.WriteLine($"Provider full name : {provider.FirstName} {provider.LastName}");
                Console.WriteLine("products {");
                ShowProducts(provider);
                Console.WriteLine("}");

            }
        }
        //End show products of all providers


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
                            provider = ProviderLogin(providers);
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
                            provider = ProviderSignUp();
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
        public static void ProviderTools(Provider provider)
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
                            ShowProducts(provider);
                            break;
                        case 2:
                            AddProduct(provider);
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

        // Start admin program
        public static void AdminProgram(List<Admin> admins, List<Provider> providers, List<User> users)
        {
            bool isRuning = true;
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Admin Menu :");
                    Console.WriteLine("1 Login");
                    Console.WriteLine("2 Sign up");
                    Console.WriteLine("3 Back to main menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    Admin admin;

                    switch (optionNumber)
                    {
                        case 1:
                            admin = AdminLogin(admins);
                            if (admin != null)
                            {
                                AdminTools(admin, providers, users);
                            }
                            else
                            {
                                Console.WriteLine("we couldn't find you , please sign up first!");
                            }

                            break;
                        case 2:
                            admin = Admin.SignUp();
                            admins.Add(admin);
                            AdminTools(admin, providers, users);
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
        // End admin program

        // Start admin tools
        public static void AdminTools(Admin admin, List<Provider> providers, List<User> users)
        {
            Console.WriteLine($"Hi {admin.FirstName} {admin.LastName}");

            bool isRuning = true;
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Admin Tools :");
                    Console.WriteLine("1 Show users");
                    Console.WriteLine("2 Show providers");
                    //Console.WriteLine("3 Delete product");
                    Console.WriteLine("3 Back to provider menu");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    switch (optionNumber)
                    {
                        case 1:
                            ShowUsers(users);
                            break;
                        case 2:
                            ShowProviders(providers);
                            break;
                        //case 3:
                        //    bool hasProductDeleted = DeleteProduct(provider);
                        //    if (hasProductDeleted)
                        //    {
                        //        Console.ForegroundColor = ConsoleColor.Green;
                        //        Console.WriteLine("product removed successfully.");
                        //        Console.ResetColor();
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("we couldn't find the prouduct!.");
                        //    }
                        //    break;
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
        // End admin program

        // Start show users
        public static void ShowUsers(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"User info: first name: {user.FirstName} , last name: {user.LastName} ");
            }
        }
        // End show users

        // Start show providers
        public static void ShowProviders(List<Provider> providers)
        {
            foreach (Provider provider in providers)
            {
                Console.WriteLine($"Provider info: first name: {provider.FirstName} , last name: {provider.LastName} ");
            }
        }
        // End show providers

        //Start user login function
        public static User UserLogin(List<User> users)
        {
            Console.WriteLine("please enter your user name");
            string username = Console.ReadLine();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == username)
                {
                    Console.WriteLine("please enter your password");
                    string password = Console.ReadLine();

                    while (true)
                    {
                        if (users[i].Password == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("you logged in successfully");
                            Console.ResetColor();
                            return users[i];
                        }
                        else
                        {
                            Console.WriteLine("your password is incorrect!");
                        }

                        Console.WriteLine("enter e to exit or any key to retry:");
                        string word = GetStringValue();

                        if (word == "e")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please enter your password");
                            password = Console.ReadLine();
                        }
                    }
                }
            }
            return null;
        }
        //End user login function

        //Start provider provider function
        public static Provider ProviderLogin(List<Provider> providers)
        {
            Console.WriteLine("please enter your user name");
            string username = Console.ReadLine();

            for (int i = 0; i < providers.Count; i++)
            {
                if (providers[i].UserName == username)
                {
                    Console.WriteLine("please enter your password");
                    string password = Console.ReadLine();

                    while (true)
                    {
                        if (providers[i].Password == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("you logged in successfully");
                            Console.ResetColor();
                            return providers[i];
                        }
                        else
                        {
                            Console.WriteLine("your password is incorrect!");
                        }

                        Console.WriteLine("enter e to exit or any key to retry:");
                        string word = GetStringValue();

                        if (word == "e")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please enter your password");
                            password = Console.ReadLine();
                        }

                    }

                }

            }

            return null;

        }
        //End provider provider function

        //Start admin login function
        public static Admin AdminLogin(List<Admin> admins)
        {
            Console.WriteLine("please enter your user name");
            string username = Console.ReadLine();

            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].UserName == username)
                {
                    Console.WriteLine("please enter your password");
                    string password = Console.ReadLine();

                    while (true)
                    {
                        if (admins[i].Password == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("you logged in successfully");
                            Console.ResetColor();
                            return admins[i];
                        }
                        else
                        {
                            Console.WriteLine("your password is incorrect!");
                        }

                        Console.WriteLine("enter e to exit or any key to retry:");
                        string word = GetStringValue();

                        if (word == "e")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please enter your password");
                            password = Console.ReadLine();
                        }

                    }

                }

            }

            return null;
        }
        //End admin login function

        //Start user sign up function
        public static User UserSignUp()
        {
            User user = new User();
            Console.WriteLine("enter your first name");
            user.FirstName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your last name");
            user.LastName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your user name");
            user.UserName = GetStringValue();
            Console.WriteLine("enter your password");
            user.Password = GetStringValue();
            Console.WriteLine("enter your phoneNumber");
            user.PhoneNumber = GetValidInputLength(GetStringValue(), minLength: 3, maxLength: 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you have successfully signed up");
            Console.ResetColor();

            return user;
        }
        //End user sign up function

        //Start provider sign up function
        public static Provider ProviderSignUp()
        {
            Provider provider = new Provider();
            Console.WriteLine("enter your first name");
            provider.FirstName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your last name");
            provider.LastName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your service");
            provider.Service = GetStringValue();
            Console.WriteLine("enter your user name");
            provider.UserName = GetStringValue();
            Console.WriteLine("enter your password");
            provider.Password = GetStringValue();
            Console.WriteLine("enter your phoneNumber");
            provider.PhoneNumber = GetValidInputLength(GetStringValue(), minLength: 3, maxLength: 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you have successfully signed up");
            Console.ResetColor();

            return provider;
        }
        //End provider sign up function

        //Start admin sign up function
        
        //End admin sign up function

        //Start separate show list function for user
        public static void ShowUserList(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"user information , first name: {user.FirstName}, last name: {user.LastName}, phone number: {user.PhoneNumber}, user name: {user.UserName}");
            }
        }
        //End separate show list function for user

        //Start separate show list function for provider
        public static void ShowProviderList(List<Provider> providers)
        {
            foreach (Provider provider in providers)
            {
                Console.WriteLine($"provider information , first name: {provider.FirstName}, last name: {provider.LastName}, phone number: {provider.PhoneNumber}, user name: {provider.UserName}, service: {provider.Service}");
            }
        }
        //End separate show list function for provider

        //Start separate show list function for admin
        public static void ShowAdminList(List<Admin> admins)
        {
            foreach (Admin admin in admins)
            {
                Console.WriteLine($"admin information , first name: {admin.FirstName}, last name: {admin.LastName}, phone number: {admin.PhoneNumber}, user name: {admin.UserName}");
            }
        }
        //End separate show list function for admin

        //Start add product
        public static void AddProduct(Provider provider)
        {
            Console.WriteLine("please enter the name of product :");
            string name = GetStringValue();
            Console.WriteLine("please enter the description of product :");
            string desciption = GetStringValue();
            Console.WriteLine("please enter the price of product :");
            string price = GetStringValue();
            Console.WriteLine("please enter the stock of product :");
            string stock = GetStringValue();

            provider.Products.Add(new Product
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
        public static bool DeleteProduct(Provider provider)
        {
            Console.WriteLine("please enter the name of the product you want to remove:");
            string name = GetStringValue();

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

        public static void ShowProducts(Provider provider)
        {
            foreach (Product product in provider.Products)
            {
                Console.WriteLine($"product info: name: {product.Name} , description: {product.Description} , price: {product.Price} , stock: {product.Stock}");
            }
        }
    }
}