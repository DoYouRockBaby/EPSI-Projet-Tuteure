using Carsale.DAO.DataAnnotations;
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
        [RequiredIfOtherEquals("BrandName", "", ErrorMessage = "Vous devez choisir une marque")]
        [RequiredIfOtherEquals("BrandName", null, ErrorMessage = "Vous devez choisir une marque")]
        public string SelectedBrandId { get; set; }

        [Display(Name = "Nom de la marque")]
        public string BrandName { get; set; }

        //?? in irad dare are hame selected hastan in nist
        [Display(Name = "Brand")]
        public IEnumerable<Brand> Brands { get; set; }

        public int Power { get; set; }

        public string Model { get; set; }

        [Required]
        [Display(Name = "Statut")]
        public StatusVehicle SelectedStatus { get; set; }

        [Required]
        [Display(Name = "Couleur")]
        public VehicleColor SelectedVehicleColor { get; set; }


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