using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{
    internal class Admin:Person
    {
        //Start admin sign up function
        public static Admin SignUp()
        {
            Admin admin = new Admin();
            admin.ReadCommonInfoForSignUp();
            return admin;
        }
        //End admin sign up function
    }
}
