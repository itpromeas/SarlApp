using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MVCWebApp.DataAccess.Data
{
    public interface IDbConnection
    {
        WebApplicationBuilder ConnectToDatabase(WebApplicationBuilder builder);

    }
}