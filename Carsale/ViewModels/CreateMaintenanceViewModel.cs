using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class CreateMaintenanceViewModel
    {
        [Required]
        public Maintenance Maintenance { get; set; }

        [Required]
        [Display(Name = "Type d'activité")]
        public string SelectedHourlyRate { get; set; }

        [Required]
        [Display(Name = "Pièces")]
        public string[] SelectedParts { get; set; }

        public IEnumerable<Part> Parts { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<HourlyRate> HourlyRates { get; set; }
    }
}