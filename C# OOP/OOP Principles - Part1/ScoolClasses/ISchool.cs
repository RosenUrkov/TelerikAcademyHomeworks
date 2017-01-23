namespace SchoolSystem
{
    using System.Collections.Generic;
    public interface ISchool
    {
        void AddClass(Class newClass);
        void AddTeacher(int classIndex, Teacher teacher);
        void AddStudent(int classIndex, Student student);
    }
}
