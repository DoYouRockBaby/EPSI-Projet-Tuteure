using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carsale.ViewModels
{
    public class CreateVehicleViewModel
    {


        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public IEnumerable<StatusVehicle> Status
        {
            get
            {
                return (StatusVehicle[])Enum.GetValues(typeof(StatusVehicle));
            }
        }

        [Required]
        public IEnumerable<VehicleColor> VehicleColor
        {
            get
            {
                return (VehicleColor[])Enum.GetValues(typeof(VehicleColor));
            }
        }
    }
}