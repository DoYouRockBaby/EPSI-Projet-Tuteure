using Carsale.DAO.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public ClientType Type { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Person)]
        [StringLength(255)]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Person)]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company)]
        [StringLength(14)]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Le SIRET n'est pas valide.")]
        [Display(Name = "SIRET")]
        public string SIRET { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company)]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Adresse")]
        public string Address1 { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Complément d'adresse")]
        public string Address2 { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Code Postal")]
        [RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Le code postal n'est pas valide.")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Pays")]
        public string Country { get; set; }
    }
}
