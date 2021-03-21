using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Customer : Account
    {
        Saving[] savings;
        public void CheckAllSavings()
        {
            for (int i = 0; i < savings.Length; i++)
            {
                savings[i].CheckInfo();
                savings[i].CheckBalance();
            }
            //Fix checkinfo and checkbalance
        }

        //Fix WithDraw and Deposti and maybe some savings control
        public void WithDraw(int pos, long input)
        {
            savings[pos].WithDraw(input);
        }

        public void Deposit(int pos, long input)
        {
            savings[pos].Deposit(input);
        }
    }
}
