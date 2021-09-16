using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Bank
{
    

    class Bank
    {
        List<Account> Accounts = new List<Account>();
        Account SelectedAccount;
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

        public void ListAccounts()
        {
            foreach (var account in Accounts)
            {
                Console.WriteLine("{0} - {1} - Account Balance: £{2}", account.Number, account.Name, account.Balance);
            }

            Console.WriteLine("\n");
        }

        public void WithdrawFunds()
        {
            try
            {
                int AccountNumber = int.Parse(Utility.Ask("Please enter Account Number:"));
                GetAccountByNumber(AccountNumber);

                if (SelectedAccount == null)
                    throw new AccountNotFoundException();

                int Amount = int.Parse(Utility.Ask("Enter Amount to withdraw:"));

                SelectedAccount.Withdraw(Amount);

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

        public void GetAccountByNumber(int AccountNumber)
        {
            SelectedAccount = null;

            foreach (var account in Accounts)
            {
                if(account.Number == AccountNumber)
                {
                    SelectedAccount = account;
                }
            }
        }
        
    }
}
