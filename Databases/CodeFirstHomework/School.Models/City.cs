namespace School.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }
    }
}
