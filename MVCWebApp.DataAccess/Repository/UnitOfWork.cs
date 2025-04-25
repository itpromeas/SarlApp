using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.DataAccess.Data;
using MVCWebApp.DataAccess.Repository.IRepository;

namespace MVCWebApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextMVCSarl _db;
        public ICategoryRepository Category {get; private set;}
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product {get; private set;}

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public ISarlUserRepository SarlUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }

        public UnitOfWork(DbContextMVCSarl db)
        {
            _db = db;
            SarlUser = new SarlUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}