namespace ProjectManager.Commands.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);

        ICommand GetCreateProjectCommand();
                 
        ICommand GetCreateUserCommand();
                 
        ICommand GetCreateTaskCommand();
                 
        ICommand GetListProjectCommand();
                 
        ICommand GetListProjectDetailsCommand();
    }
}
