using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Data
{
    public interface IDbConnection
    {
        WebApplicationBuilder ConnectToDatabase(WebApplicationBuilder builder);

    }
}