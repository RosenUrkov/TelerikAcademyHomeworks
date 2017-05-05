namespace AcademyEcosystemCLI.Models.Plants
{
    using Contracts;

    public class Bush : Plant, IPlant
    {
        public Bush(IPoint location)
            : base(location, 4)
        {
        }
    }
}
