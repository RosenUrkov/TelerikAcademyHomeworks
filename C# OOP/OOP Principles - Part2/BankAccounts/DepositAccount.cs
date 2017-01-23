using System;

namespace BankSystem
{
    public class DepositAccount : BankAccount, IBankAccount
    {
        public DepositAccount(Customer customer, decimal initialBalance)
            : base(customer, initialBalance)
        {
        }

        public override double CalculateInterestRate(int numberOfMonths)
        {            
            if (this.Balance > 0 && this.Balance < 1000)
            {
                this.InterestRate = 0;
            }
            else
            {
                this.InterestRate = 1;
            }
            return base.CalculateInterestRate(numberOfMonths);
        }

        public override void Draw(decimal amountOfMoney)
        {
            if (amountOfMoney < 0)
            {
                throw new ArgumentException("Amount of money cant be negative number.");
            }
            this.Balance -= amountOfMoney;
        }
    }
}
