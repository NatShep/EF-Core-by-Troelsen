using System.Collections.Generic;
using AutoLotDal_Core.Models;

namespace AutoLotDal_Core2.Repos
{
    public interface IInventoryRepo: IRepo<Inventory>
    {
        
        List<Inventory> GetPinkCars();
        List<Inventory> GetRelatedData();
    }
}