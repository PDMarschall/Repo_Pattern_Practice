using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.Repository
{
    public interface IRepository<T>
    {
        T Delete(T entity);
        T Update(T entity);
        T Insert(T entity);
        IEnumerable<T> Select(Expression<Func<T, bool>> predicate);
        void SaveChanges();

    }
}
