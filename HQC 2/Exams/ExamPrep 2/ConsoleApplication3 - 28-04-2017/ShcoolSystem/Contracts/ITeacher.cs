namespace SchoolSystem.Contracts
{
    using SchoolSystem.Enums;

    /// <summary>
    /// Represents extended person abstraction that have subject and can add marks to students
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subjct Subject { get; }

        void AddMark(IStudent student, float value);
    }
}
