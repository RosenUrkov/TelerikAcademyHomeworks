namespace SchoolSystem
{
    using System.Collections.Generic;
    public class Teacher : Person
    {
        private List<Discipline> teacherDisciplines;

        public Teacher(string lastName): base(lastName)
        {
            teacherDisciplines = new List<Discipline>();
        }

        public Teacher(string lastName,List<Discipline> disciplines) :this(lastName)
        {
            teacherDisciplines.AddRange(disciplines);
        }

        public List<Discipline> TeacherDisciplines
        {
            get
            {
                return new List<Discipline>(this.teacherDisciplines);
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            teacherDisciplines.Add(discipline);
        }
    }
}
