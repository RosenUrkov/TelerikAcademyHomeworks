namespace ProjectManager.Core.Contracts
{
    public interface IFileLogger
    {
        void Info(string message);

        void Error(string message);

        void Fatal(string message);
    }
}
