using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "L'email renseigné n'est pas valide.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        public AccountType Type { get; set; }
    }
}
