using System.Data.Entity;
using SampleApp.Data.Models;

namespace SampleApp.Data
{
    public interface ISampleDbContext
    {
        IDbSet<Person> Persons { get; set; }
    }
}