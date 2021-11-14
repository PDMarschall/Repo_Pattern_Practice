using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
