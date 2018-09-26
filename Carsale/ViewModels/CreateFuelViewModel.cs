using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carsale.ViewModels
{
    public class CreateFuelViewModel
    {
        [Required]
        public Fuel Fuel { get; set; }

        [Required]
        [Display(Name = "Grossiste")]
        public string SelectedFuelWholesaler { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string SelectedType { get; set; }

        public IEnumerable<FuelWholesaler> FuelWholesalers { get; set; }

        public IEnumerable<FuelType> FuelTypes
        {
            get
            {
                return (FuelType[])Enum.GetValues(typeof(FuelType));
            }
        }
    }
}