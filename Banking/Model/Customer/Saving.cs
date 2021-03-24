using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    class Saving
    {
        enum SavingType
        {
            OneMonth,
            ThreeMonth,
            SixMonth,
            OneYear
        }
        long iBalance;
        char[] cCreateDate;
        SavingType type;
        float fRate;
        int time;

        public Saving(long input)
        {
            this.iBalance = input;
        }
        public void CheckInfo()
        {
            //do something
        }
        public long CheckBalance()
        {
            //do something
            return iBalance;
        }
        public void WithDraw(long input)
        {
            this.iBalance = this.iBalance - input;
            //do more thing
        }
        public void Deposit(long input)
        {
            this.iBalance = this.iBalance + input;
            //do even more thing
        }
    }
}
