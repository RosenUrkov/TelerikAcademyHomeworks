namespace AcademyEcosystemCLI.Models.Plants
{
    using Contracts;

    public class Tree : Plant, IPlant
    {
        public Tree(IPoint location)
            : base(location, 15)
        {
        }
    }
}
