using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SarlApp.Data
{
    public class DbConnectionSarl
    {
        private readonly IDbConnection _dbConnection;

        public DbConnectionSarl(IDbConnection db)
        {
            _dbConnection = db;
        }

        public WebApplicationBuilder Connect(WebApplicationBuilder builder)
        {
            // put your code here
            return _dbConnection.ConnectToDatabase(builder);
        }
    }
}