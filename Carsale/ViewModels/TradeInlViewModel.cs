using Carsale.DAO.DataAnnotations;
using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace Carsale.ViewModels
{
    public class TradeInlViewModel
    {
        [Required]
        [Display(Name = "Reprise")]
        public TradeIn TradeIn { get; set; }

        [Required]
        [Display(Name = "Reprise ID")]
        public int TradeInID { get; set; }

        [Required]
        [Display(Name = "Vente")]
        public Sale Sale { get; set; }

        [Required]
        [Display(Name = "Vente ID")]
        public int SaleID { get; set; }


        [Display(Name = "Vehicule de reprise")]
        public Vehicle TradeInVehicle { get; set; }
        

        [Display(Name = "Client")]
        public Client Client { get; set; }

        [Required]
        [Display(Name = "Client")]
        public string ClientId { get; set; }

        [Required]
        [Display(Name = "Nom Marque")]
        public string BrandName { get; set; }

        [Display(Name = "Marque")]
        [RequiredIfOtherEquals("BrandName", "", ErrorMessage = "Vous devez choisir une marque")]
        [RequiredIfOtherEquals("BrandName", null, ErrorMessage = "Vous devez choisir une marque")]
        public string SelectedBrandId { get; set; }

        [Required]
        [Display(Name = "Vehicule")]
        public string Matriculation { get; set; }

        [Required]
        [Display(Name = "Vehicule")]
        public string TradeInMatriculation { get; set; }

        [Required]
        [Display(Name = "Brands")]
        public IEnumerable<Brand> Brands { get; set; }

        [Required]
        [Display(Name = "Couleur")]
        public string SelectedVehicleColor { get; set; }  

        public IEnumerable<VehicleColor> VehicleColor
        {
            get
            {
                return (VehicleColor[])Enum.GetValues(typeof(VehicleColor));
            }
        }
    }
}