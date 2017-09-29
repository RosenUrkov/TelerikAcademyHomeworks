namespace SampleApp.Data
{
    using SampleApp.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SampleDbContext : DbContext, ISampleDbContext
    {
        private const string ConnectionStringName = "SampleDb";

        public SampleDbContext() : base(ConnectionStringName)
        {
        }

        // i know its people, but i want my table to be named 'person'
        public virtual IDbSet<Person> Persons { get; set; }
    }
}