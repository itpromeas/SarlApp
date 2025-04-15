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
            _db.Products.Update(item);
        }
    }
}
