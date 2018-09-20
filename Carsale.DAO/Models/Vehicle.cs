using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Models
{
  public  enum VehicleColor
    {
        Red,
        Yellow,
        Gold,
        Black,
        White,
        Green ,
        Beige ,
        Maroon
    }
    
    public class Vehicle
    {
        [Key]
        public string Matriculation { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public Brand Brand { get; set; }

        [Required]
        [Display(Name = "Vehicle Color")]
        public VehicleColor VehicleColor { get; set; }

        [Required]
        [Display(Name = "Power")]
        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Status")]
        public StatusVehicle Status { get; set; }        
    }
}
