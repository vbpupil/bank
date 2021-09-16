using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    enum Option
    {
        Create_Account,
        List_Accounts,
        Select_Account,
        Delete_Account,   
        Withdraw_Funds,
        Deposit_Funds,
        Transfer_Funds
    }

    class Menu
    {
        public Option MenuOption;
        public string OptionsString;
        Bank Bank;

        public Menu(Bank bank)
        {
            Bank = bank;
            Init();
            DisplayMenu();
        }

        private void Init()
        {
            /* Generate menu options from Enum (Options) and store in OptionString */
            OptionsString = "";
            int Index = 0;

            foreach (var option in Enum.GetValues(typeof(Option)))
            {
                OptionsString += Index + " - " + option + "\n";
                Index++;
            }
        }

        public void DisplayMenu(bool ClearConsole = false)
        {
            try
            {
                if (ClearConsole)
                    Console.Clear();

                MenuOption = (Option) int.Parse(Utility.Ask("Please select from the following options:\n\n"+ OptionsString));

                // check if selection is outside of Enum (Options) list count.
                if ((int) MenuOption < 0 || (int) MenuOption > (Enum.GetNames(typeof(Option)).Length - 1))
                    throw new FormatException();

                Console.Clear();
                
                HandleSelection((int) MenuOption);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("** Invalid selection, please try again. **\n");
                DisplayMenu();
            }
            
        }

        public void HandleSelection(int MenuOption)
        {
            switch (MenuOption)
            {
                case 0:
                    Bank.CreateAccount();
                    DisplayMenu();
                    break;
                case 1:
                    Bank.ListAccounts();
                    DisplayMenu();
                    break;
                case 2:
                    Console.WriteLine("Select Account Event");
                    //Bank.
                    break;
                case 3:
                    Console.WriteLine("Delete Account Event");
                    break;
                case 4:
                    Bank.WithdrawFunds();
                    DisplayMenu();
                    break;
                case 5:
                    Console.WriteLine("Deposit Funds Event");
                    break;
                case 6:
                    Console.WriteLine("Transfer Funds Event");
                    break;
            }
        }
    }
}
