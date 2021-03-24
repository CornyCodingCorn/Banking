using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    class Admin : Account
    {
        Teller[] tellerAccounts;
        public Admin()
        {
            //.............
        }

        public void CreateTellerAccount()
        {
            Teller teller = new Teller();
            tellerAccounts.Append<Teller>(teller);
        }
        public void DeleteTellerAccount(int pos)
        {
            tellerAccounts = tellerAccounts.Where((source, index) => index != pos).ToArray();
        }
        //Rename a b c and Fix function
        public void ShowDailyReport(int a, int b, int c)
        {

        }
        public void ShowMonthlyReport(int a, int b)
        {

        }
        public void ShowAnualReport(int a)
        {

        }
    }
}
