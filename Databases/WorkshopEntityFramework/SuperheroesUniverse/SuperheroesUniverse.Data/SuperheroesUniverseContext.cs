using SuperheroesUniverse.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseContext : DbContext
    {
        public SuperheroesUniverseContext() 
            : base("SuperheroesUniverse")
        {
        }

        public IDbSet<Superhero> Superheroes { get; set; }

        public IDbSet<Relationship> Relationships { get; set; }

        public IDbSet<Power> Powers { get; set; }

        public IDbSet<Fraction> Fractions { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Planet> Planets { get; set; }
    }
}
