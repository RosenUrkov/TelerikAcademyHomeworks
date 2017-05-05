namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents abstraction that have fist and last name
    /// </summary>
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }
    }
}
