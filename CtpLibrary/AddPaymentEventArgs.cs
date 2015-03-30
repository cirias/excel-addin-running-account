using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtpLibrary
{
    public class AddPaymentEventArgs : EventArgs
    {
        private readonly string name;

        public string Name
        {
            get { return name; }
        }

        private readonly double money;

        public double Money
        {
            get { return money; }
        }

        private readonly string firstType;

        public string FirstType
        {
            get { return firstType; }
        }

        private readonly string secondType;

        public string SecondType
        {
            get { return secondType; }
        }

        private readonly DateTime dateTime;

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        private readonly string accountName;

        public string AccountName
        {
            get { return accountName; }
        }

        private readonly bool isExpense;

        public bool IsExpense
        {
            get { return isExpense; }
        } 
        
        public AddPaymentEventArgs(string Name, double Money, string FirstType, string SecondType, DateTime dateTime, string AccountName, bool isExpense)
        {
            this.name = Name;
            this.money = Money;
            this.firstType = FirstType;
            this.secondType = SecondType;
            this.dateTime = dateTime;
            this.accountName = AccountName;
            this.isExpense = isExpense;
        }
    }
}
