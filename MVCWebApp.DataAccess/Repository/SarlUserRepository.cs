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
    public class SarlUserRepository : Repository<SarlUser>, ISarlUserRepository
    {
        private DbContextMVCSarl _db;
        public SarlUserRepository(DbContextMVCSarl db) : base(db)
        {
            this._db = db;
        }
    }
}
