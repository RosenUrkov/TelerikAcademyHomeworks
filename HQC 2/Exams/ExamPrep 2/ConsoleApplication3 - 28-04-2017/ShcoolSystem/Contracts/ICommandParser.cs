namespace SchoolSystem.Contracts
{    
    /// <summary>
    /// Represents parser that process commands as string and return them as executable command
    /// </summary>
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
    }
}
