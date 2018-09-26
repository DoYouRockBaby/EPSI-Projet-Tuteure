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
            
            if(Enum.TryParse(viewModel.SelectedStatus, out StatusVehicle status))
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

            IEnumerable<Vehicle> vehicles= vehicleProvider.FindAll();
            if (selectedStatus==null && selectedBrandId==null && selectedColor == null)
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
            else { 
                if(viewModel.BrandName != null && viewModel.BrandName != "")
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
                    if(Int32.TryParse(viewModel.SelectedBrandId, out int brandId))
                    {
                        viewModel.Vehicle.Brand = brandProvider.FindById(brandId);
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
                SelectedBrandId= vehicle.BrandId.ToString(),
                Vehicle = vehicle,
                Brands = brands,
                Power=vehicle.Power,
                Model = vehicle.Model,
                SelectedStatus = vehicle.Status,
                SelectedVehicleColor = vehicle.VehicleColor,
                BrandName = vehicle.Brand.Name,
                Price = vehicle.Price
            };
            ViewBag.Brands= brandProvider.FindAll();
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
                    BrandId =int.Parse(viewModel.SelectedBrandId),
                    Model = viewModel.Model,
                    VehicleColor = viewModel.SelectedVehicleColor,
                    Status =viewModel.SelectedStatus,
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
            if (vehicle==null)
            {
                return HttpNotFound();
            }
           
            ViewBag.BrandName = vehicle.Brand.Name;

            return View(vehicle);

        }
        [HttpPost]
        //sara
        public ActionResult Delete(Vehicle Vehicle)
        {
            vehicleProvider.Delete(Vehicle.Matriculation);
            return RedirectToAction("List");

        }



    }

}
