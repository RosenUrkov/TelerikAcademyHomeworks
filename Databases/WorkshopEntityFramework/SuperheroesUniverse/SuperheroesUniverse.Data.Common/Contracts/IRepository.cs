using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Common.Contracts
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> All(Expression<Func<T, bool>> expression);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);
    }
}
