using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager, AccountType.MaintenanceAgent })]
    public class HourlyRateController : AbstractController
    {
        HourlyRateProvider hourlyRateProvider;

        public HourlyRateController(HourlyRateProvider hourlyRateProvider)
        {
            this.hourlyRateProvider = hourlyRateProvider;
        }

        // GET: HourlyRate
        public ActionResult List()
        {
            var viewModel = new HourlyRateHistoryViewModel()
            {
                MechanicalHourlyRates = hourlyRateProvider.FindFromMaintenanceType(MaintenanceType.Mechanical),
                ElectricalHourlyRates = hourlyRateProvider.FindFromMaintenanceType(MaintenanceType.Electrical),
                ElectronicalHourlyRates = hourlyRateProvider.FindFromMaintenanceType(MaintenanceType.Electronical),
                BodyHourlyRates = hourlyRateProvider.FindFromMaintenanceType(MaintenanceType.Body)
            };

            return View(viewModel);
        }

        // POST: HourlyRate/Create
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Price,MaintenanceType")] HourlyRate hourlyRate)
        {
            if(hourlyRate != null)
            {
                hourlyRate.DateTime = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                hourlyRateProvider.Add(hourlyRate);
            }

            return RedirectToAction("List");
        }
    }
}
