namespace AcademyEcosystemCLI.Contracts
{
    public interface IHerbivore : IOrganism, IAnimal
    {
        int EatPlant(IPlant plant);
    }
}
