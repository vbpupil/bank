using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Account
    {
        public string Name;
        public int Number;
        private int balance = 0;
        public int Balance
        {
            get { return balance;  }
            set { balance = value; }
        }

        public Account(string name)
        {
            Name = name;
            Number = Name.GetHashCode();
            NewAccountOffer();
        }

        //public Account()
        //{
        //    NewAccountOffer();
        //}

        public int Withdraw(int Amount)
        {
            if (Amount < 0 || Balance < Amount)
            {
                throw new InvalidAmountException();
            }

            this.Balance = this.Balance - Amount;

            return Amount;
        }

        public void Deposit(int Amount)
        {
            this.Balance += Amount;
        }

        public void GetBalance()
        {
            Console.WriteLine("The Account #: {0} has a balance of: £{1}", this.Number, this.Balance);
        }

        private void NewAccountOffer(bool Apply = true)
        {
            this.Balance += 100;
        }
    }
}
