using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MVCWebApp.DataAccess.Data
{
    public class MSSQLConnection : IDbConnection
    {
        public WebApplicationBuilder ConnectToDatabase(WebApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}