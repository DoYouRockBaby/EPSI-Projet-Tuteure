using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}
