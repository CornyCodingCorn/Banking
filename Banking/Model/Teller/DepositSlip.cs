using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    class DepositSlip : Slip
    {
        public DepositSlip(uint uiMoney) : base(uiMoney)
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
