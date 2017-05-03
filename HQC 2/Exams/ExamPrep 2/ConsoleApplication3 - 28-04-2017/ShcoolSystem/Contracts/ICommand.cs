namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents executable command for the engine to work with
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with specific parameters and returns the execution result
        /// </summary>
        /// <param name="parameters">Parameters of the command</param>
        /// <returns>Returns the execution result of the command.</returns>
        string Execute(IList<string> parameters);
    }
}
