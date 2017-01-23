namespace BankAccounts
{
    using System;
    using BankSystem;
    using System.Collections.Generic;
    public class Bank : IBank
    {
        private Dictionary<string, BankAccount> bankAccounts;

        public Bank()
        {
            bankAccounts = new Dictionary<string, BankAccount>();
        }

        public Dictionary<string, BankAccount> BankAccounts
        {
            get
            {
                return new Dictionary<string, BankAccount>(this.bankAccounts);
            }
        }

        public void AddAccount(string name ,Account accountType, Customer customer, decimal initialBalance)
        {
            switch (accountType)
            {
                case Account.Deposit:
                    bankAccounts.Add(name, new DepositAccount(customer, initialBalance));
                    break;
                case Account.Loan:
                    bankAccounts.Add(name, new LoanAccount(customer, initialBalance));
                    break;
                case Account.Morgage:
                    bankAccounts.Add(name, new MorgageAccount(customer, initialBalance));
                    break;
                default:
                    break;
            }
        }        

        public void RemoveAccount(string name)
        {
            this.bankAccounts.Remove(name);
        }
    }
}
