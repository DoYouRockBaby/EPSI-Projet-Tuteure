﻿using Carsale.DAO.Models;
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

        public VehicleController(VechicleProvider vechicleProvider)
        {
            this.vechicleProvider = vechicleProvider;
        }
       
        public ActionResult List()
        {
            ViewBag.Vehicles = vechicleProvider.FindAll();
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new CreateVehicleViewModel();
            Vehicle vehicle = new Vehicle();
            viewModel.Vehicle = vehicle;

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
    }
}