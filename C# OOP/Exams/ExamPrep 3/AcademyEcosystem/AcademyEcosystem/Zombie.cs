
namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        public Zombie(string name, Point location) : base(name, location, 0)
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
