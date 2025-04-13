using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;

namespace MVCWebApp.Data
{
    public class DbContextMVCSarl : DbContext
    {
        public DbContextMVCSarl(DbContextOptions<DbContextMVCSarl> options) : base(options)
        {
        
        }

        public DbSet<CategoryModel> Categories { get; set; }

        // this is to create some Dummy Data in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel{Id = 1, Name = "Online Class", DisplayOrder = 1},
                new CategoryModel{Id = 2, Name = "Real Estate", DisplayOrder = 2},
                new CategoryModel{Id = 3, Name = "Shop", DisplayOrder = 3}
            );
        }
    }
}