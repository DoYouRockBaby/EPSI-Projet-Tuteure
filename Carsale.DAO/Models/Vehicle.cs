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
        [Required(ErrorMessage = "Vous devez renseigner l'immatriculation de la voiture")]
        [Display(Name = "Immatriculation")] 
        public string Matriculation { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un prix d'achat")]
        [Display(Name = "Prix")]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Display(Name = "Marque")]
        public Brand Brand { get; set; }

        [Display(Name = "Marque")]
        public int BrandId { get; set; }
        
        [Required(ErrorMessage = "Vous devez choisir une couleur de voiture")]
        [Display(Name = "Couleur")]
        public VehicleColor VehicleColor { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une puissance de moteur")]
        [Display(Name = "Puissance")]
        [Range(1, int.MaxValue)]
        public int Power { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un modèle de vehicule")]
        [StringLength(255, ErrorMessage = "La taille maximale du modèle est de 255 caractères")]
        [Display(Name = "Modèle")]
        public string Model { get; set; }

        public double Mileage { get; set; }

        [Required(ErrorMessage = "Vous devez choisir le statut vehicule")]
        [Display(Name = "Status")]
        public StatusVehicle Status { get; set; }

    }
}
