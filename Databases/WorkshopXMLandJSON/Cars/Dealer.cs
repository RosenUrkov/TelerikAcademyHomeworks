namespace Cars
{
    public class Dealer
    {
        public string Name { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $@"
_________________________________
Name: {this.Name},
City: {this.City}
_________________________________
";
        }
    }
}
