
namespace AnimalHieararchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private int age;
        private static Random genderGenerator;

        static Animal()
        {
            genderGenerator = new Random();
        }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = (Sex)genderGenerator.Next(0, 2);
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException("Age must be a number between 0 and 0.");
                }
                this.age = value;
            }
        }

        public string Name { get; set; }

        public Sex Sex { get; protected set; }

        public abstract string MakeNoise();

        public static double AverageAge(IEnumerable<Animal> animalCollection)
        {
            var result = (animalCollection.Sum(animal => animal.Age)) / (double)(animalCollection.Count());
            return Math.Round(result,2);
        }
       
    }
}
