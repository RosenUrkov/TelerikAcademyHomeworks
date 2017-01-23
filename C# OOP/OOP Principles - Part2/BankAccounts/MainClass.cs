namespace BankAccounts
{
    using System;
    public class MainClass
    {
        public static void Main()
        {
            var myBank = new Bank();
            myBank.AddAccount("Pesho Petrov", BankSystem.Account.Deposit, BankSystem.Customer.Individual, 524.76m);
            myBank.AddAccount("ASD Invest", BankSystem.Account.Loan, BankSystem.Customer.Company, 2652.8536m);
            myBank.AddAccount("Kiro EOOD", BankSystem.Account.Morgage, BankSystem.Customer.Company, 6521.4125m);

            myBank.BankAccounts["Kiro EOOD"].Deposit(523.50m);
            myBank.BankAccounts["Pesho Petrov"].Draw(50);

            foreach (var account in myBank.BankAccounts)
            {
                Console.WriteLine(account.Value.CalculateInterestRate(7));
            }
        }
    }
}
