using Carsale.DAO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class CreateMaintenanceBillViewModel
    {
        public MaintenanceBill MaintenanceBill { get; set; }

        [Required]
        [Display(Name = "Client")]
        public string SelectedClient { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public Maintenance Maintenance { get; set; }
    }
}