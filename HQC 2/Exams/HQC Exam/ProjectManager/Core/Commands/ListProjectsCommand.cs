namespace ProjectManager.Core.Commands
{
    using Common.Contracts;
    using Contracts;
    using ProjectManager.Data;
    using System;
    using System.Collections.Generic;

    public class ListProjectsCommand : ListingCommand, ICommand
    {
        public ListProjectsCommand(IDatabase datebase, IValidator validator = null)
            : base(datebase, validator)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            base.Execute(parameters);

            return string.Join(Environment.NewLine, this.Datebase.Projects);
        }

        protected override int GetParametersCount()
        {
            return 0;
        }
    }
}
