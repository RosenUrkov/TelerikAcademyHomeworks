namespace AcademyEcosystemCLI.Models.Animals
{
    using Contracts;
    using Enums;

    public class Zombie : Animal, IAnimal, IOrganism
    {
        public Zombie(string name, IPoint location) : base(name, location, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
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
