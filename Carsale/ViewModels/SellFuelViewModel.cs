using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class SellFuelViewModel
    {
        [Required]
        public FuelSale Sale { get; set; }

        [Required(ErrorMessage = "Vous devez selectionner un client")]
        public string SelectedVehicleId { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}