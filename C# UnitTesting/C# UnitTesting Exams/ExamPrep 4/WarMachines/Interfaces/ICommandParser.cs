using System.Collections.Generic;

namespace WarMachines.Interfaces
{
    public interface ICommandParser
    {
        IList<ICommand> ReadCommands();
    }
}
