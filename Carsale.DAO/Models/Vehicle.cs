using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }

        public int SaleId { get; set; }

        [Required]
        [Display(Name = "Immatriculation")] 
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

        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }
    }
}
