namespace BankSystem
{
    public interface IBankAccount
    {
        Customer Customer { get; set; }
        decimal Balance { get; }

        void Deposit(decimal amountOfMoney);
        void Draw(decimal amountOfMoney);
        double CalculateInterestRate(int numberOfMonths);
    }
}
