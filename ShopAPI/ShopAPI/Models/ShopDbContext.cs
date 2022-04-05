using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ShopDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Car>().ToTable("Car", "Shop");
            modelBuilder.Entity<Warehouse>().ToTable("Warehouse", "Shop");
            modelBuilder.Entity<Location>().ToTable("Location", "Shop");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle", "Shop");

            modelBuilder.Entity<Car>(entity => { 
                entity.HasKey(e => e._ID);
                entity.HasIndex(e => e.WarehouseID);
            });
            modelBuilder.Entity<Warehouse>(entity => { entity.HasKey(e => e._ID); });
            modelBuilder.Entity<Location>(entity => { 
                entity.HasKey(e => e._ID);
                entity.HasIndex(e => e.WarehouseID);
            });
            modelBuilder.Entity<Vehicle>(entity => { 
                entity.HasKey(e => e._ID);
                entity.HasIndex(e => e.CarID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
