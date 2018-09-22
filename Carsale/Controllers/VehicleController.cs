using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class VehicleController : Controller
    {
        private VechicleProvider vechicleProvider;
        private BrandProvider brandProvider;
        public VehicleController(VechicleProvider vechicleProvider, BrandProvider brandProvider)
        {
            this.vechicleProvider = vechicleProvider;
            this.brandProvider = brandProvider;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            ViewBag.LoggedUser = Session["User"];
            base.OnActionExecuting(filterContext);
        }

        public ActionResult List()
        {
            ViewBag.Vehicles = vechicleProvider.FindAll();
            return View();
        }

        public ActionResult Create()
        {
            IEnumerable<Brand> brands = brandProvider.FindAll();
            var viewModel = new CreateVehicleViewModel();
            Vehicle vehicle = new Vehicle();
            viewModel.Vehicle = vehicle;
            viewModel.Brands = brands;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                vechicleProvider.Add(viewModel.Vehicle);
                return RedirectToAction("List","Vehicle");
            }

            return View(viewModel);
        }

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
            var viewModel = new CreateVehicleViewModel();            
            viewModel.Vehicle = vehicle;
            viewModel.Brands = brands;   
           

            return View(viewModel);
        }


        [HttpPost, LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.DirectionAssistant })]
        public ActionResult Edit(String matriculation, CreateVehicleViewModel viewModel)
        {
            //Check if the user exists
            if (vechicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("Le véhicule n'existe pas.");
            }
           /// viewModel.Vehicle.Matriculation = matriculation;
            if (ModelState.IsValid)
            {
                vechicleProvider.Update(viewModel.Vehicle);
            }
            return View(viewModel);
        }


        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Delete(String matriculation)
        {
            //Check if the user exists
            if (vechicleProvider.FindByMatriculation(matriculation) == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            vechicleProvider.Delete(matriculation);

            return RedirectToAction("List", "Vehicle");
        }

    }

}