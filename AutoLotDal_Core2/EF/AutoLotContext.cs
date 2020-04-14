using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoLotDal_Core.Models;

namespace AutoLotDal_Core.EF
{
    public class AutoLotContext:DbContext
    {
        
        public AutoLotContext(DbContextOptions options) : base(options)
        {
            
        }

        public AutoLotContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=desktop-l8k07nf\\sqlexpress;Initial Catalog=AutoLotCore;User Id=sa;Password=123;MultipleActiveResultSets=True;App=EntityFramework";
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            }
        }
        
        public DbSet<CreditRisk> CreditRisks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasIndex(e => new {e.FirstName, e.LastName}).IsUnique();
            });

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Car)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

   //     public string GetTableName(Type type)
     //   {
       //     return Model.FindEntityType(type).SqlServer().TableName;
       // }
    }
}