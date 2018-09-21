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
    public class VehicleController : Controller
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
            ViewBag.Vehicles = vechicleProvider.FindAll();
            return View();
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
                vechicleProvider.Add(viewModel.Vehicle);
                return RedirectToAction("List");
            }

            viewModel.Brands = brandProvider.FindAll();
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
    }
}