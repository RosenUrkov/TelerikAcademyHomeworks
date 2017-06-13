namespace SchoolSystem.Framework.Models.Contracts
{
    public interface ISchoolSystem
    {
        void AddStudent(int studentId, IStudent student);

        void RemoveStudent(int studentId);

        IStudent GetStudent(int studentId);

        void AddTeacher(int teacherId, ITeacher teacher);

        void RemoveTeacher(int teacherId);

        ITeacher GetTeacher(int teacherId);
    }
}
