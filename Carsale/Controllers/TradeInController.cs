﻿using Carsale.DAO.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using Carsale.DAO.Models;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader })]
    public class TradeInController : Controller
    {

        private TradeInProvider tradeInProvider;
        private ClientProvider clientProvider;
        private VehicleProvider vehicleProvider;
        private SaleProvider saleProvider;
        private BrandProvider brandProvider;
        public TradeInController(TradeInProvider tradeInProvider, ClientProvider clientProvider, SaleProvider saleProvider,
            VehicleProvider vehicleProvider, BrandProvider brandProvider)
        {
            this.tradeInProvider = tradeInProvider;
            this.clientProvider = clientProvider;
            this.vehicleProvider = vehicleProvider;
            this.brandProvider = brandProvider;
            this.saleProvider = saleProvider;
        }

        public ActionResult List()
        {
            return View(tradeInProvider.FindAll());

        }


        public ActionResult Create(string matriculation)
        {
            Vehicle NewVehicle = vehicleProvider.FindByMatriculation(matriculation);
            string brandName = NewVehicle.Brand.Name;
            TradeInlViewModel viewModel = new TradeInlViewModel()
            {
                BrandName = brandName,
                ClientId = 1,
                Brands = brandProvider.FindAll()

            };
            ViewBag.NewVehicle = NewVehicle;
            return View("Create", viewModel);
        }
        [HttpPost]
        public ActionResult Create(string matriculation, TradeInlViewModel viewModel)
        {

            var vehicle = vehicleProvider.FindByMatriculation(matriculation);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le vehicule n'existe pas.");
            }

               
               Vehicle tradInvehicle = vehicleProvider.FindByMatriculation(viewModel.TradeInMatriculation);

            if (tradInvehicle != null)
            {
                tradInvehicle.VehicleColor = (VehicleColor)Enum.Parse(typeof(VehicleColor), viewModel.SelectedVehicleColor);
                tradInvehicle.Status = StatusVehicle.Used;
                tradInvehicle.Price = viewModel.TradeInVehicle.Price;
                tradInvehicle.Mileage = viewModel.TradeInVehicle.Mileage;
                vehicleProvider.Update(tradInvehicle);
                viewModel.TradeInVehicle = tradInvehicle;

            }
            else
            {
                tradInvehicle = new Vehicle();
                tradInvehicle.Matriculation = viewModel.TradeInMatriculation;
                tradInvehicle.VehicleColor = (VehicleColor)Enum.Parse(typeof(VehicleColor), viewModel.SelectedVehicleColor);
                tradInvehicle.BrandId = Int32.Parse(viewModel.SelectedBrandId);
                tradInvehicle.Status = StatusVehicle.Used;
                tradInvehicle.Model = viewModel.TradeInVehicle.Model;
                tradInvehicle.Price = viewModel.TradeInVehicle.Price;
                tradInvehicle.Mileage = viewModel.TradeInVehicle.Mileage;
                tradInvehicle.Power = viewModel.TradeInVehicle.Power;
                vehicleProvider.Add(tradInvehicle);
                viewModel.TradeInVehicle = tradInvehicle;
            }

            TradeIn tradeIn = new TradeIn();
            Sale sale = new Sale();
            tradeIn.MatriculationNew = viewModel.Matriculation;
            tradeIn.MatriculationTradeIn = viewModel.TradeInMatriculation;
            tradeIn.DateTradeIn = DateTime.Now;
            tradeIn.Mileage = viewModel.TradeInVehicle.Mileage;
            tradeIn.Price = vehicle.Price - viewModel.TradeInVehicle.Price;
            sale.Date = DateTime.Now;
            sale.ClientId = 1;
            tradeIn.ClientId = 1;
            sale.VehicleMatriculation = vehicle.Matriculation;
            sale.Price = vehicle.Price;
            tradeInProvider.Add(tradeIn);
            saleProvider.Add(sale);
            viewModel.ClientId = 1;
            
            viewModel.SaleID = sale.Id;
            viewModel.TradeInID = tradeIn.Id;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateClient", "TradeIn", viewModel);
            }

            else 
            return RedirectToAction("List", "Vehicle",viewModel);
        }

        public ActionResult CreateClient(TradeInlViewModel viewModel)
        {
            viewModel = ViewBag.TradeIdEnd;
            return View("CreateClient", viewModel);
        }

        [HttpPost]
        public ActionResult TradeInEnd(TradeInlViewModel viewModel)
        {

            Client client = viewModel.Client;
            clientProvider.Add(client);
            TradeIn tradeIn = new TradeIn();
            Client clientValidation = clientProvider.FindById(client.Id);
            tradeIn = tradeInProvider.FindById(viewModel.TradeInID);
            tradeIn.ClientId = clientValidation.Id;
            tradeIn.Client = client;
            Sale sale = new Sale();
            
            sale = saleProvider.FindById(viewModel.SaleID);
            sale.Client = client;
            sale.ClientId = clientValidation.Id;
            tradeInProvider.Update(tradeIn);
            saleProvider.Update(sale);
            
           
               
                ViewBag.Error = "Data Added Success!";
                return RedirectToAction("List","Vehicle");
          
        }

    }
}