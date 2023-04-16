using CustomerCRUDApp_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDApp_DAL.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProduct> CustomerProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("ApplicationCustomers");
            modelBuilder.Entity<Customer>()
                .HasKey(k => k.CustomerId)
                .HasName("CustomerAppId");
            modelBuilder.Entity<Product>().ToTable("ApplicationProducts");
            modelBuilder.Entity<Product>()
                .HasKey(k => k.ProductId)
                .HasName("ProductAppId");
            modelBuilder.Entity<CustomerProduct>().HasKey(k => new { k.ProductId, k.CustomerId });
        }
    }
}
