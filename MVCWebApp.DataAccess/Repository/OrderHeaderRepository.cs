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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private DbContextMVCSarl _db;
        public OrderHeaderRepository(DbContextMVCSarl db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }
    }
}
