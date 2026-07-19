using BookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _phoneNumber;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _lastName = value;
                }
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;

            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;

            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value.Length == 11)
                {
                    _phoneNumber = value;
                }

            }
        }

        protected void ReadCommonInfoForSignUp()
        {
            Console.WriteLine("enter your first name");
            FirstName = InputHelper.GetValidInputLength(InputHelper.GetStringValue(), minLength: 3);
            Console.WriteLine("enter your last name");
            LastName = InputHelper.GetValidInputLength(InputHelper.GetStringValue(), minLength: 3);
            Console.WriteLine("enter your user name");
            UserName = InputHelper.GetStringValue();
            Console.WriteLine("enter your password");
            Password = InputHelper.GetStringValue();
            Console.WriteLine("enter your phoneNumber");
            PhoneNumber = InputHelper.GetValidInputLength(InputHelper.GetStringValue(), minLength: 3, maxLength: 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("you have successfully signed up");
            Console.ResetColor();
 
        }
    }
}
