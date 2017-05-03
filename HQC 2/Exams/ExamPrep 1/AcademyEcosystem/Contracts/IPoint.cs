namespace AcademyEcosystemCLI.Contracts
{
    public interface IPoint
    {
        int X { get; }
        
        int Y { get; }

        int GetHashCode();

        string ToString();
    }
}
