using System;
using System.Net;
using System.Web.Mvc;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;

namespace Carsale.Controllers
{
    public class SaleController : AbstractController
    {
        SaleProvider saleProvider = new SaleProvider();
        ClientProvider clientProvider = new ClientProvider();
        VechicleProvider vehicleProvider = new VechicleProvider();

        public SaleController(SaleProvider saleProvider, ClientProvider clientProvider, VechicleProvider vehicleProvider)
        {
            this.saleProvider = saleProvider;
            this.clientProvider = clientProvider;
            this.vehicleProvider = vehicleProvider;
        }

        // GET: Sale
        public ActionResult List()
        {
            return View(saleProvider.FindAll());
        }

        // GET: Sale/Create/5, id is the vehicle id
        public ActionResult Create(string id)
        {
            var vehicle = vehicleProvider.FindByMatriculation(id);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le vehicule n'existe pas.");
            }

            var viewModel = new SellViewModel()
            {
                Sale = new Sale()
                {
                    VehicleMatriculation = id
                },
                Vehicle = vehicle,
                VehicleId = id,
                Clients = clientProvider.FindAll()
            };

            return View(viewModel);
        }

        // POST: Sale/Create/5, id is the vehicle id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id, SellViewModel viewModel)
        {
            var vehicle = vehicleProvider.FindByMatriculation(id);
            if (vehicle == null)
            {
                return new HttpNotFoundResult("Le vehicule n'existe pas.");
            }

            if (viewModel.Sale != null)
            {
                viewModel.Sale.Date = DateTime.Now;
                if(viewModel.ClientId != null && viewModel.ClientId != "" && Int32.TryParse(viewModel.ClientId, out int clientId))
                {
                    viewModel.Sale.ClientId = clientId;
                    viewModel.Sale.VehicleMatriculation = id;
                }
            }

            if (ModelState.IsValid)
            {
                saleProvider.Add(viewModel.Sale);
                return RedirectToAction("List");
            }

            viewModel.Clients = clientProvider.FindAll();

            return View(viewModel);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SaleDate,SalePrice")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                saleProvider.Update(sale);
            }

            return View(sale);
        }
    }
}
