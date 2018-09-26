using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class FuelWholesaler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Address { get; set; }
    }
}
