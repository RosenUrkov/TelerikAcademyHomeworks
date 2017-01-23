namespace AnimalHieararchy
{
    using System;
    public class Frog : Animal
    {
        private Random poisonRoulette;

        public Frog(string name, int age) : base(name, age)
        {
            poisonRoulette = new Random();
            IsPoison = poisonRoulette.Next(0, 2) > 0 ? true:false;
        }

        public bool IsPoison { get;}

        public override string MakeNoise()
        {
            return "Crok crrok";
        }
    }
}
