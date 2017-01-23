using System;

namespace BankSystem
{
    public class LoanAccount : BankAccount, IBankAccount
    {
        public LoanAccount(Customer customer, decimal initialBalance) : base(customer, initialBalance)
        {
        }

        public override double CalculateInterestRate(int numberOfMonths)
        {
            base.CalculateInterestRate(numberOfMonths);
            if ((numberOfMonths <= 3 && this.Customer == Customer.Individual)
                || (numberOfMonths <= 2 && this.Customer == Customer.Company))
            {
                InterestRate = 0;
            }
            else
            {
                InterestRate = 1;
            }
            return base.CalculateInterestRate(numberOfMonths);
        }
    }
}
