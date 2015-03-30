using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtpLibrary
{
    public class AddTransferEventArgs : EventArgs
    {
        private readonly DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
        } 

        private readonly string outAccount;

        public string OutAccount
        {
            get { return outAccount; }
        }

        private readonly string inAccount;

        public string InAccount
        {
            get { return inAccount; }
        }

        private readonly decimal money;

        public decimal Money
        {
            get { return money; }
        }

        public AddTransferEventArgs(DateTime dateTime, string outAccount,string inAccount, decimal money)
        {
            this.dateTime = dateTime;
            this.outAccount = outAccount;
            this.inAccount = inAccount;
            this.money = money;
        }
    }
}
