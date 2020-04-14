using System;
using AutoLotDal_Core.EF;
using AutoLotDal_Core.Models;
using AutoLotDal_Core2.DataInitializator;
using AutoLotDal_Core2.Repos;

namespace AutoLotDal_Core2.TestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EF Core 2");
            using (var context = new AutoLotContext())
            {
               MyDataInitializer.RecreateDatabase(context);
               MyDataInitializer.InitializeData(context);
                foreach (var car in context.Cars)
                {
                    Console.WriteLine(car);
                }
            }
            
            Console.WriteLine("Using Repository");
            using (var repo = new InventoryRepo())
            {
                foreach (var car in repo.GetAll())
                {
                    Console.WriteLine("Repo: " + car);
                }
            }
            Console.ReadLine();

        }
    }
}