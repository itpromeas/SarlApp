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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private DbContextMVCSarl _db;
        public OrderDetailRepository(DbContextMVCSarl db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
