namespace AcademyEcosystemCLI.Models.Plants
{
    using Contracts;

    public class Grass : Plant, IOrganism, IPlant
    {
        public Grass(IPoint location) : base(location, 2)
        {
        }

        public override void Update(int time)
        {
            base.Update(time);
            if (this.IsAlive)
            {                
                this.Size += time;
            }
        }
    }
}
