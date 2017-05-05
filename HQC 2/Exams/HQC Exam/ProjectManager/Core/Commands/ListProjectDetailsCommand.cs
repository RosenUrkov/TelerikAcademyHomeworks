namespace ProjectManager.Core.Commands
{
    using Common.Contracts;
    using Contracts;
    using Data;
    using System.Collections.Generic;

    public class ListProjectDetailsCommand : ListingCommand, ICommand
    {
        private const string InvalidProjectIdMessage = "Project with this id does not exist.";

        public ListProjectDetailsCommand(IDatabase datebase, IValidator validator = null) 
            : base(datebase, validator)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            base.Execute(parameters);

            int id = int.Parse(parameters[0]);
            return this.Datebase.Projects[id].ToString();
        }

        protected override int GetParametersCount()
        {
            return 1;
        }
    }
}
