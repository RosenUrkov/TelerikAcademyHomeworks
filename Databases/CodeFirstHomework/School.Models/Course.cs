namespace School.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.Materials = new HashSet<Material>();

            this.Students = new HashSet<Student>();

            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual City City { get; set; }

        [Index]
        public virtual Course ParentCourse { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
