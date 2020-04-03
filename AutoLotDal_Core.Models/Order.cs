using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDal_Core.Models.Base;

namespace AutoLotDal_Core.Models
{
    public class Order: EntityBase
    {
        public int CustId { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CustId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CarId))]
        public Inventory Car { get; set; }
        
    }
}