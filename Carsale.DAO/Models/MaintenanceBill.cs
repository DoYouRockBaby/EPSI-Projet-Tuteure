using System;
using System.ComponentModel.DataAnnotations;

namespace Carsale.DAO.Models
{
    public class MaintenanceBill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Statut")]
        public MaintenanceBillStatus Status { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Client")]
        public Client Client { get; set; }

        [Display(Name = "Entretient")]
        public int MaintenanceId { get; set; }

        [Display(Name = "Entretient")]
        public Maintenance Maintenance { get; set; }
    }
}
