using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Models
{
    public class  Sale
    {
        #region Keys
        [Key]
        public int  Id { get; set; }
 
        public string VehicleId { get; set; }
        public int ClientId { get; set; }
        #endregion

        #region Properties
        [Required(ErrorMessage = "Date Is Required!")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        public double Price { get; set; }
        #endregion

        #region Relations
        public Vehicle Vehicle { get; set; }
        public Client Client { get; set; }
        #endregion
    }
}
