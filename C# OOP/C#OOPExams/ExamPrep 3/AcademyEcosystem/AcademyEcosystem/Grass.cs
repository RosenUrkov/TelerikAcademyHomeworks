namespace AcademyEcosystem
{
    public class Grass : Plant, IOrganism
    {
        public Grass(Point location) : base(location, 2)
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
