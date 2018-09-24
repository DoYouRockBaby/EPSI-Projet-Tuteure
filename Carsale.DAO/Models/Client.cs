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

        [Required(ErrorMessage = "Vous devez choisir un type de client")]
        [Display(Name = "Type")]
        public ClientType Type { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Person, ErrorMessage = "Vous devez renseigner le prénom")]
        [StringLength(255, ErrorMessage = "La taille maximale du prenom est de 255 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Person, ErrorMessage = "Vous devez renseigner le nom")]
        [StringLength(255, ErrorMessage = "La taille maximale du nom est de 255 caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company, ErrorMessage = "Vous devez renseigner le SIRET")]
        [StringLength(14, ErrorMessage = "La taille maximale du SIRET est de 14 caractères")]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Le SIRET n'est pas valide.")]
        [Display(Name = "SIRET")]
        public string SIRET { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company, ErrorMessage = "Vous devez renseigner le nom de l'entreprise")]
        [StringLength(255, ErrorMessage = "La taille maximale du nom de l'entreprise est de 255 caractères")]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [RequiredIfOtherEquals("Type", ClientType.Company, ErrorMessage = "Vous devez renseigner une brève description de l'entreprise")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une adresse")]
        [StringLength(255, ErrorMessage = "La taille maximale de l'adresse est de 255 caractères")]
        [Display(Name = "Adresse")]
        public string Address1 { get; set; }

        [StringLength(255, ErrorMessage = "La taille maximale du complément d'adresse est de 255 caractères")]
        [Display(Name = "Complément d'adresse")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner le code postal de l'adresse")]
        [StringLength(10, ErrorMessage = "La taille maximale du code postal est de 10 caractères")]
        [Display(Name = "Code Postal")]
        [RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Le code postal n'est pas valide.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Vous renseigner le pays de l'adresse")]
        [StringLength(255, ErrorMessage = "La taille maximale du pays est de 10 caractères")]
        [Display(Name = "Pays")]
        public string Country { get; set; }
    }
}
