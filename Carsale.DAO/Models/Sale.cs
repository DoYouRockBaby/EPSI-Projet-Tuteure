using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class  Sale
    {
        #region Keys
        [Key]
        public int  Id { get; set; }

        public string VehicleMatriculation { get; set; }
        public int ClientId { get; set; }
        #endregion

        #region Properties
        [Required(ErrorMessage = "Vous devez renseigner une date de vente")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un prix de vente")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        #endregion

        #region Relations
        public Vehicle Vehicle { get; set; }
        public Client Client { get; set; }
        #endregion
        public Sale()
        {

        }
    }
}
