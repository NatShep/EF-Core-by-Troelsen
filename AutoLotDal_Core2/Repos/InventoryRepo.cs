using System.Collections.Generic;
using System.Linq;
using AutoLotDal_Core.EF;
using AutoLotDal_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLotDal_Core2.Repos
{
    public class InventoryRepo: BaseRepo<Inventory>, IInventoryRepo
    {

        public override List<Inventory> GetAll() => GetAll(x => x.PetName, true);
        public InventoryRepo(AutoLotContext context) : base(context)
        {
            
        }


        public List<Inventory> GetPinkCars() => GetSome(x => x.Color == "Pink");

        public List<Inventory> GetRelatedData() => ContextDb.Cars.FromSqlRaw("SELECT * FROM Inventory")
            .Include(x => x.Orders).ThenInclude(x => x.Customer).ToList();
    }
}