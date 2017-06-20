using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SuperheroesUniverse.Data.Common.Contracts;
using System.Data.Entity;
using System.Linq;

namespace SuperheroesUniverse.Data.Common
{
    public class Repository<T> : IRepository<T> 
        where T : class
    {
        private readonly IDbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> expression)
        {
            return this.dbSet.Where(expression).ToList();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }       

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }
    }
}
