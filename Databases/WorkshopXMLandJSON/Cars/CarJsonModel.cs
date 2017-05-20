namespace Cars
{
    public class CarJsonModel
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public Dealer Dealer { get; set; }
    }
}
