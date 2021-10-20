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
    }
}