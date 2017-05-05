namespace ProjectManager.Core.Commands.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
