using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Fuel
    {
        [Key]
        public string Reference { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Type")]
        public FuelType Type { get; set; }

        [Display(Name = "Grossiste")]
        public int FuelWholesalerId { get; set; }

        [Display(Name = "Grossiste")]
        public FuelWholesaler FuelWholesaler { get; set; }
    }
}
