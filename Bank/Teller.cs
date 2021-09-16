using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Teller
    {
        public string Name { get; set; }

        public void Transfer(Account AccountFrom, Account AccountTo, int Amount)
        {
            try
            {
                var sum = AccountFrom.Withdraw(Amount);
                AccountTo.Deposit(sum);
                Console.WriteLine("Successfully Transferred £{0}\n", Amount);
                Console.WriteLine("Account: {0} Current Balance: {1}", AccountFrom.Number, AccountFrom.Balance);
                Console.WriteLine("Account: {0} Current Balance: {1}", AccountTo.Number, AccountTo.Balance);
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

        public void Greet()
        {
            Console.WriteLine("Hi I'm {0},how may i help you today?\n", this.Name);
        }

    }
}
