using System;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location) : base(name, location, 6)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (this.Size * 2 >= animal.Size))
            {
                this.Size++;
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
