using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory3.Models;

namespace Inventory3.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext (DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FixAsset> FixAssets { get; set; }
        public DbSet<Category> Categorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department")
                .HasMany(e => e.Employees);
            modelBuilder.Entity<Employee>().ToTable("Employee")
                .HasMany(e => e.Locations)
                .WithOne(c => c.Employee)
                .OnDelete(DeleteBehavior.SetNull)
                ;
            modelBuilder.Entity<Location>().ToTable("Location")
                .HasMany(e => e.FixAssets)
                .WithOne(c => c.Location)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<FixAsset>().ToTable("FixAsset");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
