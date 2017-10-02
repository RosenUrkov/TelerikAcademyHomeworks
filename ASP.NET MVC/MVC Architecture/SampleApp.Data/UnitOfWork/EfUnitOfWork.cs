using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly SampleDbContext context;

        public EfUnitOfWork(SampleDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
