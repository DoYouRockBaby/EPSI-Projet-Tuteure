using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Models
{
  
   public class  Sale
    {
        [Key]
        public int  Id { get; set; }

 
        [Required(ErrorMessage = "Date Is Required!")]
        public DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        public int SalePrice { get; set; }
    }
}
