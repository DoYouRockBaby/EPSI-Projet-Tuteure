using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner le nom de votre marque")]
        [StringLength(255, ErrorMessage = "La taille maximale du nom est de 255 caractères")]
        [Display(Name = "Nom")]
        public string Name { get; set; }
    }
}
