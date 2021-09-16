using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teller teller = new Teller() { Name = "Maggy" };

            //Account account1 = new Account() { Number = "001" };
            //Account account2 = new Account() { Number = "002" };

            //teller.Greet();
            //teller.Transfer(account1, account2, 50);
            //teller.Transfer(account1, account2, 100);

            Menu menu = new Menu(new Bank("Lloyds Bank"));

        }
    }
}
