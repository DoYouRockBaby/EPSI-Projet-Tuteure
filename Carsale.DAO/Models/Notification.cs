using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Models
{
   public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un Titre")]
        [Display(Name = "Title")]
        public string Title  { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner un Text")]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une date de Debut")]
        [Display(Name = "DateDebut")]
        public string ShowDate { get; set; }
    }
}
