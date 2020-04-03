using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDal_Core.Models.Base;

namespace AutoLotDal_Core.Models
{
    [Table("CreditRisks")]

    public class CreditRisk:EntityBase
    {
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
    }
}