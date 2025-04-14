using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.DataAccess.Data;
using MVCWebApp.DataAccess.Repository.IRepository;
using MVCWebApp.Models;

namespace MVCWebApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        private readonly DbContextMVCSarl _db;
        public CategoryRepository(DbContextMVCSarl db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CategoryModel item)
        {
            _db.Categories.Update(item);
        }
    }
}