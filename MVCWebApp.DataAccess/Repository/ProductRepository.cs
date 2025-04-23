using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebApp.DataAccess.Data;
using MVCWebApp.DataAccess.Repository.IRepository;
using MVCWebApp.Models;

namespace MVCWebApp.DataAccess.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        private readonly DbContextMVCSarl _db;
        public ProductRepository(DbContextMVCSarl db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductModel item)
        {
            //_db.Products.Update(item);
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == item.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = item.Title;
                objFromDb.Price = item.Price;
                objFromDb.Price50 = item.Price50;
                objFromDb.ListPrice = item.ListPrice;
                objFromDb.Price100 = item.Price100;
                objFromDb.Description = item.Description;
                objFromDb.CategoryId = item.CategoryId;
                objFromDb.Author = item.Author;
                if (item.ImageUrl != null)
                {
                    objFromDb.ImageUrl = item.ImageUrl;
                }
            }
        }
    }
}
