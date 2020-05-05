using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using AutoLotDal_Core.Models.Base;

namespace AutoLotDal_Core.Models
{
    public partial class Customer:EntityBase
    {
      
        public override string ToString()
        {
            return $"{this.FirstName?? "**No Name"} {this.LastName}";
        }
        
    }
}