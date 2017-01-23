using System;

namespace SchoolSystem
{
    public class Discipline
    {
        private int lectionsNumber;
        private int exercisesNumber;

        public Discipline(string name, int numberofLections, int numberOfExercises)
        {
            this.DisciplineName = name;
            this.LectionsNumber = numberofLections;
            this.ExercisesNumber = numberOfExercises;
        }

        public string DisciplineName { get; set; }
        public int LectionsNumber
        {
            get
            {
                return this.lectionsNumber;
            }
            set
            {
                CorrectNumberValidation(value);
                this.lectionsNumber = value;
            }
        }
        public int ExercisesNumber
        {
            get
            {
                return this.exercisesNumber;
            }
            set
            {
                CorrectNumberValidation(value);
                this.exercisesNumber = value;
            }
        }

        private void CorrectNumberValidation(int value)
        {
            if (value < 0 || value > int.MaxValue)
            {
                throw new ArgumentException("Number must be 0 or positive.");
            }
        }
    }
}
