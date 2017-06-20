using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Planet
    {
        public Planet()
        {
            this.Countries = new HashSet<Country>();
            this.Fractions = new HashSet<Fraction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public virtual ICollection<Fraction> Fractions { get; set; }
    }
}