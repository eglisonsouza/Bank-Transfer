using System;
using Bank.Transfer.Class.Account;
using Bank.Transfer.Enum;

namespace Bank.Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account
                (
                    name: "Eglison",
                    balance: 0,
                    credit: 0,
                    accountType: AccountType.LegalPerson 
                );
            Console.WriteLine(myAccount.ToString());
        }
    }
}