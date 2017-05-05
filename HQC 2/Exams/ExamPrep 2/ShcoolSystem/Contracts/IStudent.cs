namespace SchoolSystem.Contracts
{
    using SchoolSystem.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Represents extended person abstraction that can have grade, marks and to list them
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; }

        List<IMark> Marks { get; }

        string ListMarks();
    }
}
