namespace Cars
{
    public class Car
    {
        public Car(int year, TransmissionType type, string manufacturer, string model, decimal price, Dealer dealer)
        {
            this.Year = year;
            this.TransmissionType = type;
            this.ManufacturerName = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Dealer = dealer;
        }

        public int Year { get; }

        public TransmissionType TransmissionType { get; }

        public string ManufacturerName { get; }

        public string Model { get; }

        public decimal Price { get;}

        public Dealer Dealer { get; }

        public override string ToString()
        {
            return $@"
---------------------------------
Year: {this.Year},
TransmissionType: {this.TransmissionType},
ManufacturerName: {this.ManufacturerName},
Model: {this.Model},
Price: {this.Price},
Dealer: {this.Dealer}
---------------------------------
";
        }
    }
}
