using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDal_Core.Models.Base;

namespace AutoLotDal_Core.Models
{
    [Table("Customers")]

    public class Customer: EntityBase
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [NotMapped] public string FullName => FirstName + " " + LastName;
        
        public ICollection<Order> Orders { get; set; }=new List<Order>();
        
    }
}