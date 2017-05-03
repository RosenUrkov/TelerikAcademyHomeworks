namespace AcademyEcosystemCLI.Contracts
{
    public interface IOrganism
    {
        bool IsAlive { get; }

        IPoint Location { get; }

        int Size { get; }

        void Update(int timeElapsed);

        void RespondTo(IOrganism organism);

        string ToString();
    }
}
