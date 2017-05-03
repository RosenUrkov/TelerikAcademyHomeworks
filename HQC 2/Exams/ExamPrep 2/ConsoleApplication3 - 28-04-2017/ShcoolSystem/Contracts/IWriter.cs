namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents abstraction that can write strings in various of ways
    /// </summary>
    public interface IWriter
    {
        void WriteLine(string text);

        void Write(string text);
    }
}
