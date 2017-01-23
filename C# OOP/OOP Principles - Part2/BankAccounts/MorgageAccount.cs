namespace BankSystem
{
    class MorgageAccount : BankAccount, IBankAccount
    {
        public MorgageAccount(Customer customer, decimal initialBalance) : base(customer, initialBalance)
        {
        }

        public override double CalculateInterestRate(int numberOfMonths)
        {
            if(numberOfMonths<=6 && this.Customer == Customer.Individual)
            {
                InterestRate = 0;
            }
            else if(numberOfMonths <= 12 && this.Customer == Customer.Company)
            {
                InterestRate = 1 / (double)2;
            }
            else
            {
                InterestRate = 1;
            }

            return base.CalculateInterestRate(numberOfMonths);
        }
    }
}
