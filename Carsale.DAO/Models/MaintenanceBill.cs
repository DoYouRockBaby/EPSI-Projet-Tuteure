using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carsale.DAO.Models
{
    public class MaintenanceBill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Statut")]
        public MaintenanceBillStatus Status { get; set; }

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
