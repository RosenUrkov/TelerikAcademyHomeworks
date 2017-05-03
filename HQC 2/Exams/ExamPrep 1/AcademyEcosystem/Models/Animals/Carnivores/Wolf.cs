namespace AcademyEcosystemCLI.Models.Animals.Carnivores
{
    using Contracts;
    using Enums;

    public class Wolf : Animal,IOrganism, IAnimal, ICarnivore
    {
        public Wolf(string name, IPoint location) : base(name, location, 4)
        {

        }

        public int TryEatAnimal(IAnimal animal)
        {            
            if (animal != null&&(this.Size >= animal.Size||animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
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

    }
}
