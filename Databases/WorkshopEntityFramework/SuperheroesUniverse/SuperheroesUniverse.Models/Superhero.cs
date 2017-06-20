using SuperheroesUniverse.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        public Superhero()
        {
            this.Powers = new HashSet<Power>();
            this.Fractions = new HashSet<Fraction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60), MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        [Index(IsUnique = true)]
        public string SecretIdentity { get; set; }

        [Required]
        public Alignment Alignment { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Story { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Power> Powers { get; set; }

        public virtual ICollection<Fraction> Fractions { get; set; }
    }
}
