using System;
using SuperheroesUniverse.Data.Common.Contracts;
using System.Data.Entity;

namespace SuperheroesUniverse.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
