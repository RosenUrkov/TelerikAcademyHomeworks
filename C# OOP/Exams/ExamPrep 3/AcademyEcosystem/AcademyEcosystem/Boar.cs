using System;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private int biteSize;

        public Boar(string name, Point location) : base(name, location, 4)
        {
            this.biteSize = 2;
        }

        public int EatPlant(Plant plant)
        {
            if(plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }
            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (this.Size >= animal.Size))
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
