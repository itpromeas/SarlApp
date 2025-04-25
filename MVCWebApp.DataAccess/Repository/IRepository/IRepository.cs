using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCWebApp.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);
    }
}