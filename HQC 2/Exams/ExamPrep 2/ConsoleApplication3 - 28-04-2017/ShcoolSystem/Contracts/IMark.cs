namespace SchoolSystem.Contracts
{
    using SchoolSystem.Enums;

    /// <summary>
    /// Represents a mark that a student can have
    /// </summary>
    public interface IMark
    {
        Subjct Subject { get; }

        float Value { get; }
    }
}
