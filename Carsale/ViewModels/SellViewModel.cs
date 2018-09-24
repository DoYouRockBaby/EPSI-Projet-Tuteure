using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class SellViewModel
    {
        [Required]
        [Display(Name = "Vente")]
        public Sale Sale { get; set; }

        [Display(Name = "Vehicule")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Clients")]
        public IEnumerable<Client> Clients { get; set; }

        [Required]
        [Display(Name = "Client")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Vehicule")]
        public string VehicleId { get; set; }
    }
}