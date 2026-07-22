using MarketplaceSystem;
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
                            User.UserProgram(users, providers);
                            break;
                        case 2:
                            Provider.ProviderProgram(providers);
                            break;
                        case 3:
                            Admin.AdminProgram(admins, providers, users);
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
    }
}