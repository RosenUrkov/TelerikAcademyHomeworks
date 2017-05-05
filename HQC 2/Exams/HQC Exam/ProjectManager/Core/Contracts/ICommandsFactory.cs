namespace ProjectManager.Core.Contracts
{
    using Commands.Contracts;

    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string command);
    }
}
