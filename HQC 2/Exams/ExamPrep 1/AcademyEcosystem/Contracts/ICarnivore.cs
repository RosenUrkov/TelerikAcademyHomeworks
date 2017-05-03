namespace AcademyEcosystemCLI.Contracts
{
    public interface ICarnivore : IOrganism, IAnimal
    {
        int TryEatAnimal(IAnimal animal);
    }
}
