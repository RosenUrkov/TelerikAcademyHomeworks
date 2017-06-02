namespace NorthwindDatabase
{
    public partial class Customer
    {
        public override string ToString()
        {
            return $"ID: {this.CustomerID}, Company name: {this.CompanyName}";
        }
    }
}
