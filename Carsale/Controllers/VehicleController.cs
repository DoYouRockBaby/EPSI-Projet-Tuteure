using Carsale.DAO.Models;
using Carsale.DAO.Providers;
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
        public VehicleController(VehicleProvider vehicleProvider, BrandProvider brandProvider)
        {
            this.vehicleProvider = vehicleProvider;
            this.brandProvider = brandProvider;
        }

        public ActionResult List()
        {


            var viewModel = new FilterViewModel()
            {
                Brands = brandProvider.FindAll(),
                Vehicles = vehicleProvider.FindAll()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult List(FilterViewModel viewModel)
        {

            StatusVehicle? selectedStatus = null;
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
        //sara
        [HttpPost]
        public ActionResult Create(CreateVehicleViewModel viewModel)
        {
            String m = viewModel.Matriculation;
            if (vehicleProvider.FindByMatriculation(m) != null)
            {
                ViewBag.MatriculationError = "Un véhicule existe déjà avec cette Immatriculation.";
            }
            else
            {
                var brand = brandProvider.FindById(int.Parse(viewModel.SelectedBrandId));
                var brands = brandProvider.FindAll();
                Vehicle oVehicle = new Vehicle();
                oVehicle.Matriculation = viewModel.Matriculation;
                oVehicle.Price = viewModel.Price;
                oVehicle.BrandId = int.Parse(viewModel.SelectedBrandId);
                oVehicle.Model = viewModel.Model;
                oVehicle.Power = viewModel.Power;
                oVehicle.Status = viewModel.SelectedStatus;
                oVehicle.VehicleColor = viewModel.SelectedVehicleColor;
                viewModel.Vehicle = oVehicle;
                viewModel.BrandName = brand.Name;
                viewModel.Vehicle.Brand = brand;
                viewModel.Brands = brands;

                if (ModelState.IsValid)
                {
                    vehicleProvider.Add(oVehicle);
                    return RedirectToAction("List", "Vehicle");
                }
            }

            return View(viewModel);
        }

        //Edit a  vehicle
        //sara
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
                Power = vehicle.Power,
                Model = vehicle.Model,
                SelectedStatus = vehicle.Status,
                SelectedVehicleColor = vehicle.VehicleColor,
                BrandName = vehicle.Brand.Name,
                Price = vehicle.Price
            };
            ViewBag.Brands = brandProvider.FindAll();
            return View(viewModel);
        }

        //Update a  vehicle
        //sara
        [HttpPost]
        public ActionResult Edit(CreateVehicleViewModel viewModel)
        {

            //Check if the user exists
            String matriculation = viewModel.Vehicle.Matriculation;
            if (vehicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("There are not this vehicle in database!");
            }

            {
                Vehicle vehicle = new Vehicle()
                {
                    Matriculation = viewModel.Vehicle.Matriculation,
                    BrandId = int.Parse(viewModel.SelectedBrandId),
                    Model = viewModel.Model,
                    VehicleColor = viewModel.SelectedVehicleColor,
                    Status = viewModel.SelectedStatus,
                    Power = viewModel.Power,
                    Price = viewModel.Price
                };

                vehicleProvider.Update(vehicle);
            }
            return RedirectToAction("List", "Vehicle");
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

        //[LoggedAuthorization]
        //public ActionResult Detail(string matriculation)

        //{
        //    //Check if the vehicle exists
        //    var vehicle = vehicleProvider.FindByMatriculation(matriculation);
        //    if (vehicle == null)
        //    {
        //        return new HttpNotFoundResult("Le véhicule n'existe pas.");
        //    }

        //    //Create default view model
        //    IEnumerable<Brand> brands = brandProvider.FindAll();
        //    var viewModel = new CreateVehicleViewModel()
        //    {
        //        SelectedBrandId = vehicle.BrandId.ToString(),
        //        Vehicle = vehicle,
        //        Brands = brands,
        //        Power = vehicle.Power,
        //        Model = vehicle.Model,
        //        SelectedStatus = vehicle.Status,
        //        SelectedVehicleColor = vehicle.VehicleColor,
        //        BrandName = vehicle.Brand.Name,
        //        Price = vehicle.Price
        //    };
        //    ViewBag.Brands = brandProvider.FindAll();
        //    return View(vehicle);
        //}
    }

}
