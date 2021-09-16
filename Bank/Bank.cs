using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bank
{
    class Bank
    {
        List<Account> Accounts = new List<Account>();
        public string Name;

        public Bank (string name)
        {
            this.Name = name;
            Console.WriteLine("Welcome To {0}\n", Name);
        }

        public void CreateAccount()
        {
            var Name = Utility.Ask("Please enter NAME of account holder:");

            Accounts.Add(new Account(Name));

            Console.WriteLine("** Account Created **");

            Utility.DelayedClear(2000);
        }

        public void CreateAccount(string Name = "")
        {
            Accounts.Add(new Account(Name));
        }

        public void ListAccounts()
        {
            foreach (var account in Accounts)
            {
                ListAccount(account);
            }

            Console.WriteLine("\n");
        }

        public void WithdrawFunds()
        {
            try
            {
                string AccountNumber = Utility.Ask("Please enter Account Number:");
                Account FoundAccount = GetAccountByNumber(AccountNumber);

                if (FoundAccount == null)
                    throw new AccountNotFoundException();

                int Amount = int.Parse(Utility.Ask("Enter Amount to withdraw:"));

                FoundAccount.Withdraw(Amount);
            }
            catch (AccountNotFoundException)
            {
                Console.WriteLine("Account could not be found");
                Utility.DelayedClear(2000);
            }
            catch (InvalidAmountException)
            {
                Console.WriteLine("Please enter a valid amount");
                Utility.DelayedClear(2000);
            }
        }

        public void FindAccount()
        {
            try
            {
                string AccountNumber = Utility.Ask("Enter Account Number:");
                Console.Clear();

                Account FoundAccount = GetAccountByNumber(AccountNumber);
                ListAccount(FoundAccount, true);
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("** Account could not be found **");
                Utility.DelayedClear(2000);
            }
        }

        public void DeleteAccount()
        {
            try
            {
                string AccountNumber = Utility.Ask("Enter Account Number:");
                Console.Clear();

                Account FoundAccount = GetAccountByNumber(AccountNumber);
                ListAccount(FoundAccount, true);

                string answer = Utility.Ask("Are you sure you want to permanently remove this account?");

                if (answer == "yes")
                    DeleteAccount(FoundAccount);
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("** Account could not be found **");
                Utility.DelayedClear(2000);
            }
        }

        private void DeleteAccount(Account Account)
        {
            Accounts.Remove(Account);
        }

        private Account GetAccountByNumber(string AccountNumber)
        {
            Account Account = Accounts.Find(account => account.Number == AccountNumber);
            return Account;
        }

        private void ListAccount(Account account, bool AddNewLine = false)
        {
            Console.WriteLine("{0} - {1} - Account Balance: £{2}", account.Number, account.Name, account.Balance);

            if (AddNewLine)
                Console.WriteLine("");
        }

        public void Transfer()
        {
            try
            {
                string From = Utility.Ask("Enter account number to remove funds from:");
                Console.Clear();

                Account AccountFrom = GetAccountByNumber(From);

                string To = Utility.Ask("Enter account to place funds in:");
                Console.Clear();

                Account AccountTo = GetAccountByNumber(To);

                int Amount = int.Parse(Utility.Ask("Enter amount to move:"));
                Console.Clear();

                Console.WriteLine("Your are moving £{0} from: {1} ({2}) to {3} ({4})\n", Amount, AccountFrom.Name, AccountFrom.Number, AccountTo.Name, AccountTo.Number);
                string Confirm = Utility.Ask("Are you sure you wish to proceed?");

                if (Confirm == "yes")
                {
                    Console.Clear();
                    Transfer(AccountFrom, AccountTo, Amount);
                }

                if (Confirm != "yes")
                {
                    Console.Clear();
                    Console.WriteLine("** Transfer Aborteed! **");
                    Utility.DelayedClear(2000);

                }
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("** Account could not be found **");
                Utility.DelayedClear(2000);
            }
        }

        private void Transfer(Account AccountFrom, Account AccountTo, int Amount)
        {
            try
            {
                var sum = AccountFrom.Withdraw(Amount);
                AccountTo.Deposit(sum);
                Console.WriteLine("** Successfully transfer of £{0}**\n", Amount);

                ListAccount(AccountFrom);
                ListAccount(AccountTo);
                Utility.DelayedClear(5000);
            }
            catch (InvalidAmountException)
            {
                Console.WriteLine("Insufficient funds!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something has gone wrong!");
            }
        }

    }
}
