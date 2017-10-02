using System.Linq;
using SampleApp.Data.Models.Contracts;

namespace SampleApp.Data.Repository
{
    public interface IEfRepostory<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}