namespace AcademyEcosystemCLI.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        void Execute(IList<string> parameters);
    }
}
