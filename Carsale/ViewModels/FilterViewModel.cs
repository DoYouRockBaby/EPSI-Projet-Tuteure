using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Carsale.DAO.Models;

namespace Carsale.ViewModels
{
    public class FilterViewModel
    {
        [Display(Name = "Brands")]
        public IEnumerable<Brand> Brands { get; set; }

        [Display(Name = "BrandId")]
        public String SelectedBrandId { get; set; }
        public IEnumerable<StatusVehicle> Status
        {
            get
            {
                return (StatusVehicle[])Enum.GetValues(typeof(StatusVehicle));
            }

        }
        public String SelectedStatus { get; set; }

        public IEnumerable<VehicleColor> VehicleColors
        {
            get
            {
                return (VehicleColor[])Enum.GetValues(typeof(VehicleColor));
            }
        }
        public String SelectedColor { get; set; }
    }
}