namespace AnimalHieararchy
{
    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public override string MakeNoise()
        {
            return "Miaau mrr mrr mial";
        }
    }
}
