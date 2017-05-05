namespace AcademyEcosystemCLI.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);

        void WriteLine(string template, params object[] parameters);
    }
}
