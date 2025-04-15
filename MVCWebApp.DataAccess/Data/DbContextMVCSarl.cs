using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;

namespace MVCWebApp.DataAccess.Data
{
    public class DbContextMVCSarl : DbContext
    {
        public DbContextMVCSarl(DbContextOptions<DbContextMVCSarl> options) : base(options)
        {
        
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        // this is to create some Dummy Data in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel{Id = 1, Name = "Online Class", DisplayOrder = 1},
                new CategoryModel{Id = 2, Name = "Real Estate", DisplayOrder = 2},
                new CategoryModel{Id = 3, Name = "Shop", DisplayOrder = 3}
            );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Title = "Product 1", ListPrice = 1, Price = 10, Price50=9, Price100=7.5, Author="Ange" },
                new ProductModel { Id = 2, Title = "Product 2", ListPrice = 1, Price = 2210, Price50=2000, Price100=1557.5, Author="Salome"}
            );
        }
    }
}