using Carsale.DAO;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader })]
    public class VehicleController : AbstractController
    {
        private VechicleProvider vechicleProvider;
        private BrandProvider brandProvider;

        public VehicleController(VechicleProvider vechicleProvider, BrandProvider brandProvider)
        {
            this.vechicleProvider = vechicleProvider;
            this.brandProvider = brandProvider;
        }

        public ActionResult List()
        {
            var viewModel = new FilterViewModel()
            {
                Brands = brandProvider.FindAll(),
                Vehicles = vechicleProvider.FindAll()
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

            IEnumerable<Vehicle> vehicles= vechicleProvider.FindAll();
            if (selectedStatus==null && selectedBrandId==null && selectedColor == null)
            {
                vehicles = vechicleProvider.FindAll();
            }
            else
            {
                vehicles = vechicleProvider.FindAll(selectedStatus, selectedBrandId, selectedColor);
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
                if(Int32.TryParse(viewModel.SelectedBrandId, out int brandId))
                {
                    viewModel.Vehicle.Brand = brandProvider.FindById(brandId);
                }
            }

            if (vechicleProvider.FindByMatriculation(viewModel.Vehicle.Matriculation) != null)
            {
                ViewBag.MatriculationError = "Un véhicule existe déjà avec cette Immatriculation.";
            }
            else
            {
                //If valid, add the vehicle to the database
                if (ModelState.IsValid)
                {
                    vechicleProvider.Add(viewModel.Vehicle);
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
            var vehicle = vechicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le véhicule n'existe pas.");
            }

             //Create default view model
            IEnumerable<Brand> brands = brandProvider.FindAll();
            var viewModel = new CreateVehicleViewModel()
            {
                Vehicle = vehicle,
                Brands = brands
            };

            
            return View(viewModel);
        }

        //Delete a new vehicle
        public ActionResult DeleteNewVehicle(String matriculation)
        {
            Vehicle vehicle = vechicleProvider.FindByMatriculation(matriculation);
            if(vehicle == null)
                {
                return new HttpNotFoundResult("There are not this vehicle in database!");
                }
            if (vehicle.Status == 0 )
            {
                vechicleProvider.Delete(matriculation);
            }
            return RedirectToAction("List");
            
        }
        
        [HttpPost, LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.DirectionAssistant })]
        public ActionResult Edit( CreateVehicleViewModel viewModel)
        {
            //Check if the user exists
            String matriculation = viewModel.Vehicle.Matriculation;
            if (vechicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("There are not this vehicle in database!");
            }
           /// viewModel.Vehicle.Matriculation = matriculation;
            if (ModelState.IsValid)
            {
                vechicleProvider.Update(viewModel.Vehicle);
            }
            return RedirectToAction("List", "Vehicle");
        }
        
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Delete(String matriculation)
        {
            //Check if the user exists
            if (vechicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("There are not this vehicle in database!");
            }

            vechicleProvider.Delete(matriculation);

            return RedirectToAction("List", "Vehicle");
        }

        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.DirectionAssistant })]
        public ActionResult Detail(String matriculation)
        {
            //Check if the vehicle exists
            var vehicle = vechicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le véhicule n'existe pas.");
            }

            return View(vehicle);
        }
    }

}
