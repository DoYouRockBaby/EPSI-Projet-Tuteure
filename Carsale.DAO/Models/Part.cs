using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez donner un nom à la pièce")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vous devez donner une brève description à la piece")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un prix")]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }
    }
}
