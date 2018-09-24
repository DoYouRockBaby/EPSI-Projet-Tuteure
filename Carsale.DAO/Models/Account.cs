using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner l'email")]
        [StringLength(255, ErrorMessage = "La taille maximale de l'email est de 255 caractères")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "L'email renseigné n'est pas valide")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un mot de passe")]
        [StringLength(255, ErrorMessage = "La taille maximale du mot de passe est de 255 caractères")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner votre prénom")]
        [StringLength(255, ErrorMessage = "La taille maximale du prenom est de 255 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner votre nom")]
        [StringLength(255, ErrorMessage = "La taille maximale du nom est de 255 caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vous devez choisir un type d'utilisateur")]
        [Display(Name = "Type")]
        public AccountType Type { get; set; }
    }
}
