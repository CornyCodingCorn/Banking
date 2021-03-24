using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public abstract class Account
    {
        enum AccountType
        {
            Teller,
            Admin,
            Customer
        }
        PersonalInfo info;
        AccountType type;
        public void ShowPersonalInfo()
        {
            //do something
        }
    }
}
