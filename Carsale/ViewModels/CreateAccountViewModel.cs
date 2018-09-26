using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Carsale.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        public Account Account { get; set; }

        [Required]
        public string RepeatPassword { get; set; }

        public string EditPassword { get; set; }
        public string EditRepeatPassword { get; set; }

        public IEnumerable<AccountType> AccountTypes
        {
            get
            {
                return (AccountType[])Enum.GetValues(typeof(AccountType));
            }
        }
    }
}