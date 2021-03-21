using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    class PersonalInfo
    {
        public struct Dob
        {
            int iDay;
            int iMonth;
            int iYear;
        }

        char[] cName;
        char[] cPhoneNumber;
        char[] cIdNumber;
        Dob dobBirth;
        public char[] GetName()
        {
            return cName;
        }

        public void SetName(char[] input)
        {
            this.cName = input;
        }

        public char[] GetIdNumber()
        {
            return cIdNumber;
        }

        public void SetIdNumber(char[] input)
        {
            this.cIdNumber = input;
        }

        public Dob GetDob()
        {
            return dobBirth;
        }

        public void SetDob(Dob input)
        {
            this.dobBirth = input;
        }
    }
}
