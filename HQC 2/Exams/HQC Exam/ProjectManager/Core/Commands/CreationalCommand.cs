namespace ProjectManager.Core.Commands
{
    using Common;
    using Common.Contracts;
    using Contracts;
    using Data;
    using Models.Contracts;
    using System.Collections.Generic;

    public abstract class CreationalCommand : ICommand
    {
        protected const string InvalidParametersMessage = "Invalid command parameters count!";
        protected const string EmptyParametersMessage = "Some of the passed parameters are empty!";
        protected const string SuccessMessage = "Successfully created a new ";        

        public CreationalCommand(IDatabase datebase, IModelsFactory factory, IValidator validator = null)
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
            this.Validator.ValidateNullObject(factory, "Factory must not be null");

            this.Factory = factory;
            this.Datebase = datebase;
        }

        public IModelsFactory Factory { get; private set; }

        public IDatabase Datebase { get; private set; }

        public IValidator Validator { get; private set; }

        public virtual string Execute(IList<string> parameters)
        {
            this.Validator.ValidateExactIntValue(parameters.Count, this.GetParametersCount(), InvalidParametersMessage);
            this.Validator.ValidateEmptyParameters(parameters, EmptyParametersMessage);

            return SuccessMessage;
        }

        protected abstract int GetParametersCount();
    }
}
