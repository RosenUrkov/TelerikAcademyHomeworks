namespace ProjectManager.Core.Contracts
{
    public interface ICommandProcessor
    {
        string Process(string commandLine);
    }
}
