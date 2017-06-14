using Academy.Commands.Contracts;

namespace Academy.Framework.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
