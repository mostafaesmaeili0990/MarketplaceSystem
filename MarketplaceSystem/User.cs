using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class User:Person
    {
        //Start user sign up function
        public static User UserSignUp()
        {
            User user = new User();
            user.ReadCommonInfoForSignUp();
            //read specialy information for user if needed
            return user;
        }
        //End user sign up function
    }
}
