using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtpLibrary
{
    public class AddAccountEventArgs:EventArgs
    {
        private readonly string strName;

        private readonly double dblMoney;

        private readonly string strFirstAccountType;

        private readonly string strSecondAccountType;

        public double DblMoney
        {
            get { return dblMoney; }
        } 

        public string StrName
        {
            get { return strName; }
        }

        public string StrSecondAccountType
        {
            get { return strSecondAccountType; }
        }

        public string StrFirstAccountType
        {
            get { return strFirstAccountType; }
        }

        public AddAccountEventArgs(string strName, double dblMoney, string strFirstAccountType, string strSecondAccountType)
        {
            this.strName = strName;
            this.dblMoney = dblMoney;
            this.strFirstAccountType = strFirstAccountType;
            this.strSecondAccountType = strSecondAccountType;
        }
    }
}
