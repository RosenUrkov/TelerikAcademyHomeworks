namespace ProjectManager.Core.Commands
{
    using Common;
    using Common.Contracts;
    using Contracts;
    using Data;
    using System;
    using System.Collections.Generic;

    public abstract class ListingCommand : ICommand
    {
        protected const string InvalidParametersMessage = "Invalid command parameters count!";
        private const string EmptyParametersMessage = "Some of the passed parameters are empty!";

        public ListingCommand(IDatabase datebase, IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }

            this.Validator.ValidateNullObject(datebase, "Datebase must not be null");
            
            this.Datebase = datebase;
        }
        
        public IDatabase Datebase { get; private set; }

        public IValidator Validator { get; private set; }

        public virtual string Execute(IList<string> parameters)
        {
            this.Validator.ValidateExactIntValue(parameters.Count, this.GetParametersCount(), InvalidParametersMessage);
            this.Validator.ValidateEmptyParameters(parameters, EmptyParametersMessage);

            return string.Empty;
        }

        protected abstract int GetParametersCount();
    }
}
