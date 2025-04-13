using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Data
{
    public class DbConnectionRazorSarl
    {
        private readonly IDbConnection _dbConnection;

        public DbConnectionRazorSarl(IDbConnection db)
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