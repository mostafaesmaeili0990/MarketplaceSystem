using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem
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
    }
}
