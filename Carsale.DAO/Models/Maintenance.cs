using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carsale.DAO.Models
{
    public class Maintenance
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vous devez donner un temps de travail")]
        [Display(Name = "Temps de travail")]
        public double WorkingTime { get; set; }

        [Required(ErrorMessage = "Vous devez renseigner la date de l'entretient")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vous devez donner une brève description de l'entretient")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Vehicule")]
        public string VehicleMatriculation { get; set; }

        [Display(Name = "Vehicule")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Taux Horaire")]
        public int HourlyRateId { get; set; }

        [Display(Name = "Taux Horaire")]
        public HourlyRate HourlyRate { get; set; }

        [Display(Name = "Pièces")]
        public ICollection<Part> Parts { get; set; }

        [NotMapped]
        public double TotalPrice
        {
            get
            {
                var price = 0.0;
                if (HourlyRate != null)
                {
                    price = HourlyRate.Price * WorkingTime;
                }

                if(Parts != null)
                {
                    foreach (var part in Parts)
                    {
                        price += part.Price;
                    }
                }

                return price;
            }
        }
    }
}
