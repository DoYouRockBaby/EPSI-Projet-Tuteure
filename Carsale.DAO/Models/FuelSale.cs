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

        [Display(Name = "Carburant")]
        public int FuelId { get; set; }

        [Display(Name = "Carburant")]
        public Fuel Fuel { get; set; }

        [Display(Name = "Vehicule")]
        public int VehicleId { get; set; }

        [Display(Name = "Vehicule")]
        public Vehicle Vehicle { get; set; }
    }
}
