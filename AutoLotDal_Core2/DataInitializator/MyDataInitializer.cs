using System;
using System.Collections.Generic;
using System.Linq;
using AutoLotDal_Core.EF;
using AutoLotDal_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AutoLotDal_Core2.DataInitializator
{
    public static class MyDataInitializer
    {
        public static void InitializeData(AutoLotContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brener"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"}
            };
            customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();

            var cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"}
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]}
            };
            orders.ForEach(x => context.Add(x));
            context.SaveChanges();

            context.CreditRisks.Add(new CreditRisk
            {
                Id = customers[4].Id,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName
            });

            context.Database.OpenConnection();
            try
            {
                // We need dbcontext to access the models
                var models = context.Model;

                // Get all the entity types information
                var entityTypes = models.GetEntityTypes();

                // T is Name of class
                var entityTypeOfT = entityTypes.First(t => t.ClrType == typeof(CreditRisk));

                var tableNameAnnotation = entityTypeOfT.GetAnnotation("Relational:TableName");
                var TableName = tableNameAnnotation.Value.ToString();
                
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{TableName} ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.CreditRisks ON;");
                
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        public static void RecreateDatabase(AutoLotContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        public static void ClearData(AutoLotContext context)
        {
            ExecuteDeleteSql(context,"Orders");
            ExecuteDeleteSql(context,"Customers");
            ExecuteDeleteSql(context,"Inventory");
            ExecuteDeleteSql(context,"CreditRisks");
  //
  // ResetIdentity(context);
        }

        public static void ExecuteDeleteSql(AutoLotContext context, string tableName)
        {
            context.Database.ExecuteSqlRaw($"Delete from dbo.{tableName}");
        }
    }
}