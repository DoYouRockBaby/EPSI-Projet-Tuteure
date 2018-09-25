using Carsale.DAO.Models;
using System.Collections.Generic;

namespace Carsale.ViewModels
{
    public class HourlyRateHistoryViewModel
    {
        public IEnumerable<HourlyRate> MechanicalHourlyRates { get; set; }
        public IEnumerable<HourlyRate> ElectricalHourlyRates { get; set; }
        public IEnumerable<HourlyRate> ElectronicalHourlyRates { get; set; }
        public IEnumerable<HourlyRate> BodyHourlyRates { get; set; }
    }
}