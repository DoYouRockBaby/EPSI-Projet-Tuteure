using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class HourlyRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Prix")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Type d'activité")]
        public MaintenanceType MaintenanceType { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
    }
}
