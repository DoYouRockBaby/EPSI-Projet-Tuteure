using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Carsale.DAO.Models
{
   public class TradeIn
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string MatriculationNew{ get; set; }
        public string MatriculationTradeIn { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner une date de reprise")]
        public DateTime DateTradeIn { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner le kilométrage")]
        public double Mileage { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner le Prix")]
        public double Price { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Client")]
        public Client Client { get; set; }

        public TradeIn()
        {

        }
    }
}
