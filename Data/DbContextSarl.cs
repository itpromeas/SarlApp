using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SarlApp.Models;

namespace SarlApp.Data
{
    public class DbContextSarl : DbContext
    {
        public DbContextSarl(DbContextOptions<DbContextSarl> options) : base(options)
        {
        
        }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}