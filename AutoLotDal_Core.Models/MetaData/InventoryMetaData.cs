using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoLotDal_Core.Models.MetaData
{
    public class InventoryMetaData
    {
        [Display(Name = "Pet Name")] public string PetName;
        [StringLength(50,ErrorMessage="Please enter a value less than 50 characters long.")]
        public string Make;
    }
}