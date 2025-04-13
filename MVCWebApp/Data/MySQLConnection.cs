using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCWebApp.Data
{
    public class MySQLConnection(string connectionString) : IDbConnection
    {
        public WebApplicationBuilder ConnectToDatabase( WebApplicationBuilder builder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 4, 3)); // On mac/Linux do:  mysql -u root -p -e "SELECT VERSION();"

            
            builder.Services.AddDbContext<DbContextMVCSarl>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 29)), // Specify your MySQL version
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                )
            );

            
            return builder;
        }
    }
}