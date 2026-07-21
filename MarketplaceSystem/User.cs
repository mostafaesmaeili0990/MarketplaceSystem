using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class User : Person
    {
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
                            user = Person.Login(users);
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
                            user = User.SignUp();
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

        //this function inherits the general function to read common info and you can get special info simultaneously
        public static User SignUp()
        {
            User user = new User();
            user.ReadCommonInfoForSignUp();
            //in this line you can get extra info
            return user;
        }

        // Start user program
        private static void UserTools(User user, List<Provider> providers)
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

        //Start show products of all providers
        public static void ShowProductsOfAllProviders(List<Provider> providers)
        {
            foreach (Provider provider in providers)
            {
                Console.WriteLine($"Provider full name : {provider.FirstName} {provider.LastName}");
                Console.WriteLine("products {");
                provider.ShowProducts();
                Console.WriteLine("}");
            }
        }
        //End show products of all providers

        
    }
}
