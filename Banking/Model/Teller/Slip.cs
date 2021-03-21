using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Slip
    {
        enum SlipType
        {
            Deposit,
            WithDraw
        }
        char[] cAccountID;
        protected uint uiMoney;
        char[] cTellerID;
        SlipType type;

        public Slip(uint input)
        {
            this.uiMoney = input;
        }
        //Remember to fix the children
        public virtual void CompleteTransaction()
        {
            // Insert code here
        }
    }
}
