namespace AnimalHieararchy
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age)
        {
            Sex = Sex.Female;
        }
    }
}
