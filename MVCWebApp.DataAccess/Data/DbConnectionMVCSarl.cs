using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MVCWebApp.DataAccess.Data
{
    public class DbConnectionMVCSarl
    {
        private readonly IDbConnection _dbConnection;

        public DbConnectionMVCSarl(IDbConnection db)
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