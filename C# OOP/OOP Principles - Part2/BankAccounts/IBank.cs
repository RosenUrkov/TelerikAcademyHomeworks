namespace BankSystem
{
    using System.Collections.Generic;
    public interface IBank
    {
        Dictionary<string, BankAccount> BankAccounts { get; }
        void AddAccount(string name , Account accountType, Customer customer, decimal initialBalance);
        void RemoveAccount(string name);
        
    }
}
