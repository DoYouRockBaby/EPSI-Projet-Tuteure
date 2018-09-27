
using Carsale.DAO.Models;
using  Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader })]
    public class VehicleController : AbstractController
    {
        private VehicleProvider vehicleProvider;
        private BrandProvider brandProvider;
        private NotificationProvider _notificationProvider;

        public VehicleController(VehicleProvider vehicleProvider, BrandProvider brandProvider, NotificationProvider notificationProvider)
        {
            this.vehicleProvider = vehicleProvider;
            this.brandProvider = brandProvider;
            this._notificationProvider = notificationProvider;
        }

        public ActionResult List()
        {

            //Filling brands and other vehicle here and then send them with our viewmodel to the view
            var viewModel = new FilterViewModel()
            {
                Brands = brandProvider.FindAll(),
                Vehicles = vehicleProvider.FindAll()
            };
            var notifications = _notificationProvider.FindAll(DateTime.Now.ToShortDateString());
            string text = "";
            foreach (var item in notifications)
            {
                text += item.Title + "\n";
                text += item.Text + "\n\n";
            }
            ViewBag.Notifications = text;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult List(FilterViewModel viewModel)
        {

            StatusVehicle selectedStatus = StatusVehicle.New;
            int? selectedBrandId = null;
            VehicleColor? selectedColor = null;

            if (Enum.TryParse(viewModel.SelectedStatus, out StatusVehicle status))
            {
                selectedStatus = status;
            }
            if (int.TryParse(viewModel.SelectedBrandId, out int bradId))
            {
                selectedBrandId = bradId;
            }
            if (Enum.TryParse(viewModel.SelectedColor, out VehicleColor couleur))
            {
                selectedColor = couleur;
            }

            IEnumerable<Vehicle> vehicles = vehicleProvider.FindAll();
            if (selectedStatus == null && selectedBrandId == null && selectedColor == null)
            {
                vehicles = vehicleProvider.FindAll();
            }
            else
            {
                vehicles = vehicleProvider.FindAll(selectedStatus, selectedBrandId, selectedColor);
            }

            viewModel = new FilterViewModel()
            {
                Brands = brandProvider.FindAll(),
                Vehicles = vehicles
            };

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CreateVehicleViewModel
            {
                Vehicle = new Vehicle(),
                Brands = brandProvider.FindAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleViewModel viewModel)
        {
            String m = viewModel.Vehicle.Matriculation;
            if (vehicleProvider.FindByMatriculation(m) != null)
            {
                ViewBag.MatriculationError = "Un véhicule existe déjà avec cette Immatriculation.";
            }
            else
            {
                if (viewModel.BrandName != null && viewModel.BrandName != "")
                {
                    //If the brandname is filled in the form, create a new brand
                    viewModel.Vehicle.Brand = new Brand()
                    {
                        Name = viewModel.BrandName
                    };

                    viewModel.Vehicle.BrandId = 0;
                }
                else
                {
                    //Add the selected brand otherwise
                    if (int.TryParse(viewModel.SelectedBrandId, out int brandId))
                    {
                        viewModel.Vehicle.BrandId = brandId;
                    }
                }

                //If valid, add the vehicle to the database
                if (ModelState.IsValid)
                {
                    vehicleProvider.Add(viewModel.Vehicle);
                    return RedirectToAction("List", "Vehicle");
                }
            }

            viewModel.Brands = brandProvider.FindAll();
            return View(viewModel);
        }

        //Edit a  vehicle
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.DirectionAssistant })]
        public ActionResult Edit(String matriculation)
        {
            //Check if the vehicle exists
            var vehicle = vehicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le véhicule n'existe pas.");
            }

            //Create default view model
            IEnumerable<Brand> brands = brandProvider.FindAll();
            var viewModel = new CreateVehicleViewModel()
            {
                SelectedBrandId = vehicle.BrandId.ToString(),
                Vehicle = vehicle,
                Brands = brands,
            };

            ViewBag.Brands = brandProvider.FindAll();
            return View(viewModel);
        }

        //Update a  vehicle
        [HttpPost]
        public ActionResult Edit(CreateVehicleViewModel viewModel)
        {
            //Check if the user exists
            String matriculation = viewModel.Vehicle.Matriculation;
            if (vehicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("Le vehicule n'existe pas dans la base de donnée");
            }

            if (viewModel.BrandName != null && viewModel.BrandName != "")
            {
                //If the brandname is filled in the form, create a new brand
                viewModel.Vehicle.Brand = new Brand()
                {
                    Name = viewModel.BrandName
                };

                viewModel.Vehicle.BrandId = 0;
            }
            else
            {
                //Add the selected brand otherwise
                if (Int32.TryParse(viewModel.SelectedBrandId, out int brandId))
                {
                    viewModel.Vehicle.BrandId = brandId;
                }
            }

            //If valid, add the vehicle to the database
            if (ModelState.IsValid)
            {
                vehicleProvider.Update(viewModel.Vehicle);
                return RedirectToAction("List", "Vehicle");
            }

            viewModel.Brands = brandProvider.FindAll();
            return View(viewModel);
        }

        //Delete a new vehicle
        //sara
        public ActionResult Delete(String matriculation)
        {
            Vehicle vehicle = vehicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            ViewBag.BrandName = vehicle.Brand.Name;

            return View(vehicle);

        }
        [HttpPost]
        //sara
        public ActionResult Delete(Vehicle vehicle)
        {
            vehicleProvider.Delete(vehicle.Matriculation);
            return RedirectToAction("List");

        }

        [LoggedAuthorization]
        public ActionResult Detail(string matriculation)
        {
            //Check if the user exists
            var vehicle = vehicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("There are not this vehicle !");
            }

            return View(vehicle);
        }

    }

}
