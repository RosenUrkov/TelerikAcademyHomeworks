namespace AcademyEcosystemCLI.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Extensions;
    using Models.Animals;
    using Models.Animals.Carnivores;
    using Models.Animals.Herbivores;
    using Models.Animals.Omnivores;
    using Models.Plants;
    using System.Linq;
    using Utils;

    public class Engine
    {
        protected static readonly char[] Separators = new char[] { ' ' };

        protected IList<IOrganism> AllOrganisms;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer, IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }

            this.Reader = reader;
            this.Writer = writer;

            this.AllOrganisms = new List<IOrganism>();
        }

        protected IValidator Validator { get; private set; }

        protected IWriter Writer
        {
            get
            {
                return this.writer;
            }
            private set
            {
                this.Validator.ValidateNullObject(value, "Writer must not be null");

                this.writer = value;
            }
        }

        protected IReader Reader
        {
            get
            {
                return this.reader;
            }
            private set
            {
                this.Validator.ValidateNullObject(value, "Reader must not be null");

                this.reader = value;
            }
        }

        public void Start()
        {
            string command = this.reader.ReadLine();
            while (command != "end")
            {
                this.ExecuteCommand(command);
                command = this.reader.ReadLine();
            }
        }

        public void AddOrganism(IOrganism organism)
        {
            this.AllOrganisms.Add(organism);
        }

        public void ExecuteCommand(string command)
        {
            string[] commandWords = command.Split(Engine.Separators, StringSplitOptions.RemoveEmptyEntries);

            if (commandWords[0] == "birth")
            {
                this.ExecuteBirthCommand(commandWords);
            }
            else
            {
                this.ExecuteAnimalCommand(commandWords);
            }

            this.RemoveAndReportDead();
        }

        protected virtual void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "deer":
                    {
                        string name = commandWords[2];
                        IPoint position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Deer(name, position));
                        break;
                    }

                case "tree":
                    {
                        IPoint position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Tree(position));
                        break;
                    }

                case "bush":
                    {
                        IPoint position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Bush(position));
                        break;
                    }

                case "grass":
                    {
                        IPoint position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Grass(position));
                        break;
                    }

                case "wolf":
                    {
                        string name = commandWords[2];
                        IPoint position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Wolf(name, position));
                        break;
                    }

                case "lion":
                    {
                        string name = commandWords[2];
                        IPoint position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Lion(name, position));
                        break;
                    }

                case "boar":
                    {
                        string name = commandWords[2];
                        IPoint position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Boar(name, position));
                        break;
                    }

                case "zombie":
                    {
                        string name = commandWords[2];
                        IPoint position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Zombie(name, position));
                        break;
                    }
            }
        }

        protected virtual void ExecuteAnimalCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "go":
                    {
                        string name = commandWords[1];
                        IPoint destination = Point.Parse(commandWords[2]);
                        destination = this.HandleGo(name, destination);
                        break;
                    }
                case "sleep":
                    {
                        string name = commandWords[1];
                        int sleepTime = int.Parse(commandWords[2]);
                        this.HandleSleep(name, sleepTime);
                        break;
                    }
            }
        }

        private IPoint HandleGo(string name, IPoint destination)
        {
            IAnimal current = this.GetAnimalByName(name);

            if (current != null)
            {
                int travelTime = Point.GetManhattanDistance(current.Location, destination);
                this.UpdateAll(travelTime);
                current.GoTo(destination);

                this.HandleEncounters(current);
            }

            return destination;
        }

        private void HandleEncounters(IAnimal current)
        {
            var allEncountered = new List<IOrganism>();
            foreach (var organism in this.AllOrganisms)
            {
                if (organism.Location == current.Location && !(organism == current))
                {
                    allEncountered.Add(organism);
                }
            }

            var currentAsHerbivore = current as IHerbivore;
            if (currentAsHerbivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsHerbivore.EatPlant(encountered as Plant);
                    if (eatenQuantity != 0)
                    {
                        this.writer.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            allEncountered.RemoveAll(o => !o.IsAlive);

            var currentAsCarnivore = current as ICarnivore;
            if (currentAsCarnivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsCarnivore.TryEatAnimal(encountered as Animal);
                    if (eatenQuantity != 0)
                    {
                        this.writer.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            this.RemoveAndReportDead();
        }

        private void HandleSleep(string name, int sleepTime)
        {
            IAnimal current = this.GetAnimalByName(name);
            if (current != null)
            {
                current.Sleep(sleepTime);
            }
        }

        private IAnimal GetAnimalByName(string name)
        {
            return this.AllOrganisms.OfType<IAnimal>().FirstOrDefault(x => x.Name == name);
        }

        protected virtual void RemoveAndReportDead()
        {
            foreach (var organism in this.AllOrganisms)
            {
                if (!organism.IsAlive)
                {
                    this.writer.WriteLine("{0} is dead ;(", organism);
                }
            }

            this.AllOrganisms.RemoveAll(o => !o.IsAlive);
        }

        protected virtual void UpdateAll(int timeElapsed)
        {
            foreach (var organism in this.AllOrganisms)
            {
                organism.Update(timeElapsed);
            }
        }
    }
}
