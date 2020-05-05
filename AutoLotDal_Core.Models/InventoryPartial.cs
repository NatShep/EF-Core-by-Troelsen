using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDal_Core.Models.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace AutoLotDal_Core.Models
{
    [ModelMetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        [NotMapped] public string FullName => $"{Make}+({Color})";
        public override string ToString()
        {
            return $"{this.PetName ?? "**No Name"} is a {this.Color} {this.Make} with ID {this.Id}";
        }
    }
}

