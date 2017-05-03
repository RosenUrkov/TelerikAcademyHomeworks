namespace AcademyEcosystemCLI.Models.Animals.Herbivores
{
    using Contracts;
    using Enums;

    public class Deer : Animal, IOrganism, IAnimal, IHerbivore
    {
        private int biteSize;

        public Deer(string name, IPoint location)
            : base(name, location, 3)
        {
            this.biteSize = 1;
        }

        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= sleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.sleepRemaining -= timeElapsed;
                }
            }

            base.Update(timeElapsed);
        }

        public int EatPlant(IPlant p)
        {
            if (p != null)
            {
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
