namespace AcademyEcosystemCLI.Contracts
{
    public interface IPlant : IOrganism
    {
        int GetEatenQuantity(int biteSize);
    }
}
