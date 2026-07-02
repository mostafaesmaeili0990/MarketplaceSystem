using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingSystem
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

            bool isRuning = true;

            //Start Main Pogram
            while (isRuning)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------");
                    Console.WriteLine("Menu :");
                    Console.WriteLine("1 Login");
                    Console.WriteLine("2 Sign up");
                    Console.WriteLine("3 Show list");
                    Console.WriteLine("4 Exit");
                    Console.WriteLine("-------------");
                    Console.ResetColor();

                    int optionNumber = Convert.ToInt32(Console.ReadLine());

                    switch (optionNumber)
                    {
                        case 1:
                            Login(users, providers, admins);
                            break;
                        case 2:
                            SignUp(users, providers, admins);
                            break;
                        case 3:
                            ShowUserList(users);
                            ShowProviderList(providers);
                            ShowAdminList(admins);
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
            //End Main Pogram
        }
        //Start login function
        public static void Login(List<User> users, List<Provider> providers, List<Admin> admins)
        {
            Console.WriteLine("please enter your user name");
            string username = Console.ReadLine();
            Console.WriteLine("please enter your password");
            string password = Console.ReadLine();

            bool isUserFound = false;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == username)
                {
                    if (users[i].Password == password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("you logged in successfully");
                        Console.ResetColor();
                        isUserFound = true;
                        break;
                    }
                }
            }
            if (!isUserFound)
            {
                for (int i = 0; i < providers.Count; i++)
                {
                    if (providers[i].UserName == username)
                    {
                        if (providers[i].Password == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("you logged in successfully");
                            Console.ResetColor();
                            isUserFound = true;
                            break;
                        }
                    }
                }
            }
            if (!isUserFound)
            {
                for (int i = 0; i < admins.Count; i++)
                {
                    if (admins[i].UserName == username)
                    {
                        if (admins[i].Password == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("you logged in successfully");
                            Console.ResetColor();
                            isUserFound = true;
                            break;
                        }
                    }
                }
            }
            if (!isUserFound)
            {
                Console.WriteLine("we couldn't find you ! please sign up first.");
            }
        }
        //End login function

        //Start signUp function
        public static void SignUp(List<User> users, List<Provider> providers, List<Admin> admins)
        {
            bool isRuning = true;

            while (isRuning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Determine your role");
                Console.WriteLine("1 User");
                Console.WriteLine("2 Provider");
                Console.WriteLine("3 Admin");
                Console.WriteLine("4 Back to menu");
                Console.ResetColor();

                int optionNumber = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (optionNumber)
                    {
                        case 1:
                            users.Add(UserSignUp());
                            userProgram();
                            isRuning = false;
                            break;
                        case 2:
                            Provider provider = ProviderSignUp();
                            providers.Add(provider);
                            providerProgram(provider);
                            isRuning = false;
                            break;
                        case 3:
                            admins.Add(AdminSignUp());
                            isRuning = false;
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
        //End signUp function

        //Start separate signUp function for user
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
        //End separate signUp function for user

        //Start separate signUp function for provider
        public static Provider ProviderSignUp()
        {
            Provider provider = new Provider();
            Console.WriteLine("enter your first name");
            provider.FirstName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your last name");
            provider.LastName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your user service");
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
        //End separate signUp function for provider

        //Start separate signUp function for admin
        public static Admin AdminSignUp()
        {
            Admin admin = new Admin();
            Console.WriteLine("enter your first name");
            admin.FirstName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your last name");
            admin.LastName = GetValidInputLength(GetStringValue(), minLength: 3);
            Console.WriteLine("enter your user name");
            admin.UserName = GetStringValue();
            Console.WriteLine("enter your password");
            admin.Password = GetStringValue();
            Console.WriteLine("enter your phoneNumber");
            admin.PhoneNumber = GetValidInputLength(GetStringValue(), minLength: 3, maxLength: 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you have successfully signed up");
            Console.ResetColor();
            return admin;
        }
        //End separate signUp function for admin

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

        //Start get string value function
        public static string GetStringValue()
        {
            string word = Console.ReadLine();
            return word;
        }
        //End get string value function

        //Start get valid input length value function
        public static string GetValidInputLength(string word, int? minLength = null, int? maxLength = null)
        {
            while (true)
            {
                if (CheckLength(word, minLength, maxLength))
                {
                    return word;
                }
                else
                {
                    if (minLength == null && maxLength == null)
                    {
                        throw new ArgumentException("specidy at least one of limitation ! (min or max)");
                    }

                    if (minLength != null)
                    {
                        Console.WriteLine($"your input should contain at least {minLength} characters");
                    }

                    if (maxLength != null)
                    {
                        Console.WriteLine($"your input can not be longer than {maxLength} characters");
                    }
                    Console.WriteLine("please enter again");
                    word = GetStringValue();

                }

            }
        }
        //End get valid input length value function

        //Start check length function
        public static bool CheckLength(string word, int? minLength = null, int? maxLength = null)
        {
            int wordLength = word.Length;

            if (minLength == null && maxLength == null)
            {
                throw new ArgumentException("specidy at least one of limitation ! (min or max)");
            }

            if (minLength != null && wordLength < minLength)
            {
                return false;
            }

            if (minLength != null && wordLength > maxLength)
            {
                return false;
            }

            return true;
        }
        //End check length function
        public static void userProgram()
        {
            Console.WriteLine("product list:");

        }

        public static void providerProgram(Provider provider)
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

            Console.WriteLine("product added successfully");

            Console.WriteLine("product info : ")

        }

    }
}