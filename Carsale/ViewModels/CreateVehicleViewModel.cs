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

        [Display(Name = "Immatriculation")]
        public string Matriculation { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Marque")]
        [RequiredIfOtherEquals("BrandName", "", ErrorMessage = "Vous devez choisir une marque")]
        [RequiredIfOtherEquals("BrandName", null, ErrorMessage = "Vous devez choisir une marque")]
        public string SelectedBrandId { get; set; }

        [Display(Name = "Nom de la marque")]
        public string BrandName { get; set; }

        
        [Display(Name = "Brand")]
        public IEnumerable<Brand> Brands { get; set; }

        public int Power { get; set; }

        public string Model { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un prix d'achat")]
        [Display(Name = "Prix")]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }

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