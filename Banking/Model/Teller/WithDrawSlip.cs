using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    class WithDrawSlip : Slip
    {
        char[] cName;
        char[] cCitizenID;
        public WithDrawSlip(uint uiMoney) : base(uiMoney)
        {
            // Insert code here
        }

        public override void CompleteTransaction()
        {
            base.CompleteTransaction();
            // Please insert code here
        }
    }
}
