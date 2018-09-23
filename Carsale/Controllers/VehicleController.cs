using Carsale.DAO;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class VehicleController : Controller
    {
        private VechicleProvider vechicleProvider;
        private CarsaleContext db = new CarsaleContext();
        private BrandProvider brandProvider;
        public VehicleController(VechicleProvider vechicleProvider, BrandProvider brandProvider)
        {
            this.vechicleProvider = vechicleProvider;
            this.brandProvider = brandProvider;
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
                return RedirectToAction("List");
            }

            return View(viewModel);
        }
        public ActionResult Index()
        {
            IEnumerable<Brand> brands = brandProvider.FindAll();
            var viewModel = new CreateVehicleViewModel();
            Vehicle vehicle = new Vehicle();
            viewModel.Vehicle = vehicle;
            viewModel.Brands = brands;

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
        //public ActionResult SaleVehicle()
        //{
            
        //}

    }
}