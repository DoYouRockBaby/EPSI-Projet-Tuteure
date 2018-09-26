using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class CreateMaintenanceViewModel
    {
        [Required]
        public Maintenance Maintenance { get; set; }

        public IEnumerable<Part> Parts { get; set; }
    }
}