using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public enum VehicleColor
    {
        Red,
        Yellow,
        Gold,
        Black,
        White,
        Green ,
        Beige ,
        Maroon
    }
    
    public class Vehicle
    {
        [Key]
        public string Matriculation { get; set; }

        [Display(Name = "Marque")]
        public Brand Brand { get; set; }

        [Display(Name = "Marque")]
        public int BrandId { get; set; }
        
        [Display(Name = "Couleur")]
        public VehicleColor VehicleColor { get; set; }

        [Required]
        [Display(Name = "Puissance")]
        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Modèle")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Status")]
        public StatusVehicle Status { get; set; }        
    }
}
