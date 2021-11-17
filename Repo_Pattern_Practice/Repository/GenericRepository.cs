using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;

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
            return context.Remove(entity).Entity;
        }

        public virtual T Insert(T entity)
        {
            return context
            .Add(entity)
            .Entity;
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
            .AsQueryable()
            .Where(predicate).ToList();
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity)
            .Entity;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Your attempted operation has been logged and HR has been notified.", "Illegal Operation.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
