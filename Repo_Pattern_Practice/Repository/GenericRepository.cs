using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext context;

        public GenericRepository(ApplicationContext applicationContext)
        {
            this.context = applicationContext;
        }

        public virtual T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Insert(T entity)
        {
            throw new NotImplementedException();
        }              

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
