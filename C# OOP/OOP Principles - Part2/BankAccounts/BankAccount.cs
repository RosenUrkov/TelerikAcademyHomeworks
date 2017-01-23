namespace BankSystem
{
    using System;
    public abstract class BankAccount : IBankAccount
    {        
        public BankAccount(Customer customer, decimal initialBalance)
        {
            this.Customer = customer;
            this.Balance = initialBalance;
        }

        public decimal Balance { get; protected set; }

        public Customer Customer { get; set; }

        protected double InterestRate {get; set; }

        public virtual double CalculateInterestRate(int numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cant be negative.");
            }
            return numberOfMonths * InterestRate;
        }

        public void Deposit(decimal amountOfMoney)
        {
            if (amountOfMoney < 0)
            {
                throw new ArgumentException("Amount of money cant be negative number.");
            }
            this.Balance += amountOfMoney;
        }
        
        public virtual void Draw(decimal amountOfmoney)
        {
            if(!(this is DepositAccount))
            {
                throw new ArgumentException("You must have deposit account to draw money.");
            }
        }


    }
}
