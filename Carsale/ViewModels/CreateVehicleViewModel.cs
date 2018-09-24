using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carsale.ViewModels
{
    public class CreateVehicleViewModel
    {
        [Required (ErrorMessage = "Vehicle doit être renseignée")]
        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Marque")]
        public string SelectedBrandId { get; set; }

        [Display(Name = "Nom de la marque")]
        public string BrandName { get; set; }

        [Display(Name = "Brand")]
        public IEnumerable<Brand> Brands { get; set; }

        [Required]
        [Display(Name = "Statut")]
        public string SelectedStatus { get; set; }

        [Required]
        [Display(Name = "Couleur")]
        public string SelectedVehicleColor { get; set; }

        public IEnumerable<StatusVehicle> Status
        {
            get
            {
                return (StatusVehicle[])Enum.GetValues(typeof(StatusVehicle));
            }
        }

        public IEnumerable<VehicleColor> VehicleColor
        {
            get
            {
                return (VehicleColor[])Enum.GetValues(typeof(VehicleColor));
            }
        }
        
    }
}