namespace ProjectManager.Models.Contracts
{
    using ProjectManager.Models.Enums;

    public interface ITask
    {
        string Name { get; }

        IUser Owner { get; }

        TaskState State { get; }

        string ToString();
    }
}
