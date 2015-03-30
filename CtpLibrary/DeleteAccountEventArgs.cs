using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtpLibrary
{
    public class DeleteAccountEventArgs:EventArgs
    {
        private readonly string strName;

        private readonly string strFirstAccountType;

        private readonly string strSecondAccountType;

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

        public DeleteAccountEventArgs(string strName, string strFirstAccountType, string strSecondAccountType)
        {
            this.strName = strName;
            this.strFirstAccountType = strFirstAccountType;
            this.strSecondAccountType = strSecondAccountType;
        }
    }
}
