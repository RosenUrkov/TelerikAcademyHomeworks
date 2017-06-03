namespace School.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();

            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(40)]
        [Required]
        public string LastName { get; set; }

        [Index(IsUnique = true)]
        public int Number { get; set; }

        [Index]
        [Required]
        public virtual City City { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
