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
        public IEnumerable<Status> Status
        {
            get
            {
                return (Status[])Enum.GetValues(typeof(Status));
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