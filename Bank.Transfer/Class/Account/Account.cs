using System;
using Bank.Transfer.Enum;

namespace Bank.Transfer.Class.Account
{
    public class Account
    {
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private AccountType AccountType { get; set; }

        public Account(string name, double balance, double credit, AccountType accountType)
        {
            Name = name;
            Balance = balance;
            Credit = credit;
            AccountType = accountType;
        }

        public bool WithdrawMoney(double value)
        {
            if (this.Balance - value < (this.Credit * -1))
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }
            this.Balance -= value;
            Console.WriteLine("The current account balance of {0} is BRL {1}.", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
            Console.WriteLine("The current account balance of {0} is BRL {1}.", this.Name, this.Balance);
        }

        public void Transfer(double value, Account destinationAccount)
        {
            if (this.WithdrawMoney(value))
            {
                destinationAccount.Deposit(value);
            }
        }

        public override string ToString()
        {
            return $@"
            Account Type: {this.AccountType} | 
            Name: {this.Name} |
            Balance: {this.Balance} |
            Credit: {this.Credit}";
        }
    }
}