using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Admin : Person
    {
        //Start admin sign up function
        public static Admin SignUp()
        {
            Admin admin = new Admin();
            admin.ReadCommonInfoForSignUp();
            //read specialy information for admin if needed
            return admin;
        }
        //End admin sign up function

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
                            admin = Person.Login(admins);
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
        private static void ShowUsers(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"User info: first name: {user.FirstName} , last name: {user.LastName} ");
            }
        }
        // End show users

        // Start show providers
        private static void ShowProviders(List<Provider> providers)
        {
            foreach (Provider provider in providers)
            {
                Console.WriteLine($"Provider info: first name: {provider.FirstName} , last name: {provider.LastName} ");
            }
        }
        // End show providers
    }
}
