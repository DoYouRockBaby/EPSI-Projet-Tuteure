using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class FuelSale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Prix")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Volume")]
        [Range(0, double.MaxValue)]
        public double Volume { get; set; }

        [Required]
        [Display(Name = "Kilométrage")]
        [Range(0, double.MaxValue)]
        public double Mileage { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Carburant")]
        public string FuelReference { get; set; }

        [Display(Name = "Carburant")]
        public Fuel Fuel { get; set; }

        [Display(Name = "Vehicule")]
        public string VehicleMatriculation { get; set; }

        [Display(Name = "Vehicule")]
        public Vehicle Vehicle { get; set; }
    }
}
