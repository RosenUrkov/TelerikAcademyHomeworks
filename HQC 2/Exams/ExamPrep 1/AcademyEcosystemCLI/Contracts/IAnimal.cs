namespace AcademyEcosystemCLI.Contracts
{
    using Enums;

    public interface IAnimal : IOrganism
    {
        AnimalState State { get; }

        string Name { get; }

        int GetMeatFromKillQuantity();

        void GoTo(IPoint destination);

        void Sleep(int time);
    }
}
