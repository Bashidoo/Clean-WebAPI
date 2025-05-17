using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Calender entity
            modelBuilder.Entity<Customer>(entity =>
            {

                entity.HasKey(e => e.Name); // or whatever your key property is7


            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
               
            });


        }
    }
}
