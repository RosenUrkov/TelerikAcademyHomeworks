namespace AnimalHieararchy
{
    using System.Collections.Generic;
    using System.Linq;
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var dogList = new List<Dog>();
            dogList.Add(new Dog("Rex", 7, "brown"));
            dogList.Add(new Dog("Buba", 4, "black"));
            dogList.Add(new Dog("Djina", 6, "white"));

            var abstractDogs = dogList.Cast<Animal>();
            var averageAge = Animal.AverageAge(abstractDogs);
            System.Console.WriteLine(averageAge);

            var frogList = new List<Frog>();
            frogList.Add(new Frog("Rex", 1));
            frogList.Add(new Frog("Buba", 2));
            frogList.Add(new Frog("Djina", 3));

            var abstractFrogs = frogList.Cast<Animal>();
            averageAge = Animal.AverageAge(abstractFrogs);
            System.Console.WriteLine(averageAge);

            var catList = new List<Cat>();
            catList.Add(new Tomcat("Rex", 3));
            catList.Add(new Kitten("Buba", 9));
            catList.Add(new Cat("Djina", 8));

            var abstractCats = catList.Cast<Animal>();
            averageAge = Animal.AverageAge(abstractCats);
            System.Console.WriteLine(averageAge);

            System.Console.WriteLine();
            System.Console.WriteLine(dogList[0].MakeNoise());
            System.Console.WriteLine(frogList[0].MakeNoise());
            System.Console.WriteLine(catList[0].MakeNoise());


        }
    }
}

