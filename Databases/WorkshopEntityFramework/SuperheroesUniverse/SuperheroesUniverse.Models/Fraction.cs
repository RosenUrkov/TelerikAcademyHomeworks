using SuperheroesUniverse.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        public Fraction()
        {
            this.Members = new HashSet<Superhero>();
            this.Planets = new HashSet<Planet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Alignment Alignment { get; set; }

        public virtual ICollection<Superhero> Members { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}