using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager, AccountType.MaintenanceAgent })]
    public class MaintenanceController : AbstractController
    {
        MaintenanceProvider maintenanceProvider;
        PartProvider partProvider;
        VechicleProvider vehicleProvider;
        HourlyRateProvider hourlyRateProvider;

        public MaintenanceController(MaintenanceProvider maintenanceProvider, PartProvider partProvider, VechicleProvider vehicleProvider, HourlyRateProvider hourlyRateProvider)
        {
            this.maintenanceProvider = maintenanceProvider;
            this.partProvider = partProvider;
            this.vehicleProvider = vehicleProvider;
            this.hourlyRateProvider = hourlyRateProvider;
        }

        // GET: Maintenance/List
        public ActionResult List()
        {
            return View(maintenanceProvider.FindAll());
        }

        // GET: Maintenance/Detail/5
        public ActionResult Detail(int id)
        {
            var maintenance = maintenanceProvider.FindById(id);
            if (maintenance == null)
            {
                return new HttpNotFoundResult("L'entretient n'existe pas.");
            }

            return View(maintenance);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            var viewModel = new CreateMaintenanceViewModel()
            {
                Maintenance = new Maintenance(),
                Parts = partProvider.FindAll(),
                Vehicles = vehicleProvider.FindAll(),
                HourlyRates = new HourlyRate[]
                {
                    hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Mechanical),
                    hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Electrical),
                    hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Electronical),
                    hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Body),
                }
            };

            return View(viewModel);
        }

        // POST: Maintenance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMaintenanceViewModel viewModel)
        {
            viewModel.Parts = partProvider.FindAll();
            viewModel.Vehicles = vehicleProvider.FindAll();
            viewModel.HourlyRates = new HourlyRate[]
            {
                hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Mechanical),
                hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Electrical),
                hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Electronical),
                hourlyRateProvider.FindLastFromMaintenanceType(MaintenanceType.Body),
            };

            //Ajout des pièces séléctionnées
            viewModel.Maintenance.Parts = new List<Part>();
            if (viewModel.SelectedParts != null)
            {
                foreach(var partIdStr in viewModel.SelectedParts)
                {
                    if(int.TryParse(partIdStr, out int partId))
                    {
                        var part = partProvider.FindById(partId);
                        if(part != null)
                        {
                            viewModel.Maintenance.Parts.Add(part);
                        }
                    }
                }
            }

            if (!int.TryParse(viewModel.SelectedHourlyRate, out int hourlyRateId) || viewModel.HourlyRates.Where(hr => hr.Id == hourlyRateId).Count() == 0)
            {
                ViewBag.HourlyRateError = "Veuillez choisir un type d'activité valide";
            }
            else
            {
                viewModel.Maintenance.HourlyRateId = hourlyRateId;
            }

            viewModel.Maintenance.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                maintenanceProvider.Add(viewModel.Maintenance);
                return RedirectToAction("List");
            }

            return View(viewModel);
        }
    }
}
