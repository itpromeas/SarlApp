using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;

namespace MVCWebApp.DataAccess.Data
{
    public class DbContextMVCSarl : IdentityDbContext<IdentityUser>
    {
        public DbContextMVCSarl(DbContextOptions<DbContextMVCSarl> options) : base(options)
        {
        
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<SarlUser> SarlUsers { get; set; }

        // this is to create some Dummy Data in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // we must put this when using IdentityDbContext

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel{Id = 1, Name = "Online Class", DisplayOrder = 1},
                new CategoryModel{Id = 2, Name = "Real Estate", DisplayOrder = 2},
                new CategoryModel{Id = 3, Name = "Shop", DisplayOrder = 3}
            );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech Solution",
                    StreetAddress = "123 Tech St",
                    City = "Tech City",
                    PostalCode = "12121",
                    State = "IL",
                    PhoneNumber = "5557770000"
                },
                new Company
                {
                    Id = 2,
                    Name = "Vivid Books",
                    StreetAddress = "333 Vid St",
                    City = "Vid City",
                    PostalCode = "5521",
                    State = "IL",
                    PhoneNumber = "7779990000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Readers Club",
                    StreetAddress = "112 Main St",
                    City = "Lala land",
                    PostalCode = "34567",
                    State = "NY",
                    PhoneNumber = "1113335555"
                }
                );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Title = "Product 1", ListPrice = 1, Price = 10, Price50=9, Price100=7.5, Author="Ange", CategoryId = 2, ImageUrl = "" },
                new ProductModel { Id = 2, Title = "Product 2", ListPrice = 1, Price = 2210, Price50=2000, Price100=1557.5, Author="Salome", CategoryId = 3, ImageUrl = "" }
            );
        }
    }
}