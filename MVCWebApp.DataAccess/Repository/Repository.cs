using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.DataAccess.Data;
using MVCWebApp.DataAccess.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVCWebApp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContextMVCSarl _db;
        internal DbSet<T> dbSet;

        public Repository(DbContextMVCSarl db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            // this.dbSet is equivalent to _db.Categories

            _db.Products.Include(u => u.Category).Include(u => u.CategoryId); // include categories
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            query = IncludeMoreProperties(includeProperties, query);
            return query.ToList();
        }

        public T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            query = IncludeMoreProperties(includeProperties, query);
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> item)
        {
            dbSet.RemoveRange(item);
        }

        private static IQueryable<T> IncludeMoreProperties(string? includeProperties, IQueryable<T> query)
        {
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query;
        }
    }
}