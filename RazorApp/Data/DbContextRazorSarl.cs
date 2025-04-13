using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorApp.Models;

namespace RazorApp.Data
{
    public class DbContextRazorSarl : DbContext
    {
        public DbContextRazorSarl(DbContextOptions<DbContextRazorSarl> options) : base(options)
        {
        
        }

        public DbSet<CategoryModelRazorApp> Categories { get; set; }

        // this is to create some Dummy Data in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModelRazorApp>().HasData(
                new CategoryModelRazorApp{Id = 1, Name = "Online Class", DisplayOrder = 1},
                new CategoryModelRazorApp{Id = 2, Name = "Real Estate", DisplayOrder = 2},
                new CategoryModelRazorApp{Id = 3, Name = "Shop", DisplayOrder = 3}
            );
        }
    }
}