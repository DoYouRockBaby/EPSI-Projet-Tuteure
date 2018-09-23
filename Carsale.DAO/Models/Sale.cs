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
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        #endregion

        #region Properties
        [Required(ErrorMessage = "Date Is Required!")]
        public DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        public long SalePrice { get; set; }
        #endregion

        #region Relations
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        #endregion
    }
}
