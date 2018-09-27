using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public string VehicleMatriculation { get; set; }
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une date de Debut")]
        [Display(Name = "DateDebut")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une duree de location")]
        [Display(Name = "Duree")]
        public int Duration => 36;

        [Required(ErrorMessage = "Vous devez renseigner un prix de location")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string Distance { get; set; }
        
        public Vehicle Vehicle { get; set; }

        public Client Client { get; set; }
    }
}
