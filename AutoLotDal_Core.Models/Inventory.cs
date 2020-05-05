using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDal_Core.Models.Base;

namespace AutoLotDal_Core.Models
{
    [Table("Inventory")]
    public partial class Inventory: EntityBase
    {
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public  string Color { get; set; }
        [StringLength(50)]
        public string PetName { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}