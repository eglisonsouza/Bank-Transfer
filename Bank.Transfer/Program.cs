using System;
using System.Collections.Generic;
using Bank.Transfer.Class.Account;
using Bank.Transfer.Enum;

namespace Bank.Transfer
{
    class Program
    {
        private static readonly List<Account> _accounts = new List<Account>();

        static void Main(string[] args)
        {
            string optionUser = GetOptionsUser();

            while (optionUser.ToUpper() != "X")
            {
                switch (optionUser)
                {
                    case "1":
                        ListAccount();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                optionUser = GetOptionsUser();
            }

            Console.WriteLine("Thank you for using our services.");
            Console.ReadLine();
        }
        
        private static void Transfer()
        {
            Console.WriteLine("Type it number of account origin");
            int inputNumberAccountOrigin = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Type it number of account destination");
            int inputNumberAccountDestination = Convert.ToInt16(Console.ReadLine());
            
            Console.WriteLine("Type it value of transfer");
            double inputValueTransfer = Convert.ToDouble(Console.ReadLine());

            _accounts[inputNumberAccountOrigin].Transfer(value: inputValueTransfer, destinationAccount: _accounts[inputNumberAccountDestination]);
        }


        private static void Deposit()
        {
            Console.WriteLine("Type it number of account");
            int inputNumberAccount = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Type it value of deposit");
            double inputValueDeposit = Convert.ToDouble(Console.ReadLine());

            _accounts[inputNumberAccount].Deposit(inputValueDeposit);
        }

        private static void Withdraw()
        {
            Console.WriteLine("Type it number of account");
            int inputNumberAccount = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Type it value of withdraw");
            double inputValueWithdraw = Convert.ToDouble(Console.ReadLine());

            _accounts[inputNumberAccount].WithdrawMoney(inputValueWithdraw);
        }
        
        private static void ListAccount()
        {
            if (_accounts.Count.Equals(0))
            {
                Console.WriteLine("Accounts is empty.");
                return;
            }

            for (int index = 0; index < _accounts.Count; index++)
            {
                Console.WriteLine($"{index} - {_accounts[index]}");
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new account");
            Console.WriteLine("Type it 1 for account physical or 2 for legal");
            int inputTypeAccount = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Type it name of client");
            string inputName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type it balance initial");
            double inputBalance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type it credit");
            double inputCredit = Convert.ToDouble(Console.ReadLine());

            _accounts.Add(new Account(
                accountType: (AccountType) inputTypeAccount,
                balance: inputBalance,
                name: inputName,
                credit: inputCredit
            ));
        }

        private static string GetOptionsUser()
        {
            Console.WriteLine();
            Console.WriteLine("Bank Transfer at you disposal.");
            Console.WriteLine("Inform the desired option.");

            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Insert new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();
            return Console.ReadLine()?.ToUpper();
        }
    }
}