namespace AnimalHieararchy
{
    public class Dog : Animal
    {
        public Dog(string name, int age , string furColor) :base(name,age)
        {
            this.FurColor = furColor;
        }

        public string FurColor { get; set; }

        public override string MakeNoise()
        {
            return "Balo balo";
        }
    }
}
