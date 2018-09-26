using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class FuelController : AbstractController
    {
        FuelProvider fuelProvider;
        FuelWholesalerProvider fuelWholesalerProvider;

        public FuelController(FuelProvider fuelProvider, FuelWholesalerProvider fuelWholesalerProvider)
        {
            this.fuelProvider = fuelProvider;
            this.fuelWholesalerProvider = fuelWholesalerProvider;
        }

        // GET: FuelWholesaler
        public ActionResult List()
        {
            return View(fuelProvider.FindAll());
        }

        // GET: FuelWholesaler/Create
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create()
        {
            var viewModel = new CreateFuelViewModel()
            {
                Fuel = new Fuel(),
                FuelWholesalers = fuelWholesalerProvider.FindAll()
            };

            return View(viewModel);
        }

        // POST: FuelWholesaler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create(CreateFuelViewModel viewModel)
        {
            viewModel.FuelWholesalers = fuelWholesalerProvider.FindAll();

            if (viewModel.SelectedFuelWholesaler != null && viewModel.SelectedFuelWholesaler != "")
            {
                if (int.TryParse(viewModel.SelectedFuelWholesaler, out int wholesalerId))
                {
                    viewModel.Fuel.FuelWholesalerId = wholesalerId;
                }
            }

            if (viewModel.SelectedType != null && viewModel.SelectedType != "")
            {
                if(Enum.TryParse(viewModel.SelectedType, out FuelType fuelType))
                {
                    viewModel.Fuel.Type = fuelType;
                }
            }

            if (ModelState.IsValid)
            {
                fuelProvider.Add(viewModel.Fuel);
                return RedirectToAction("List");
            }

            return View(viewModel);
        }

        // GET: FuelWholesaler/Edit/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(string id)
        {
            Fuel fuel = fuelProvider.FindByReference(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CreateFuelViewModel()
            {
                Fuel = fuel,
                FuelWholesalers = fuelWholesalerProvider.FindAll()
            };

            return View(viewModel);
        }

        // POST: FuelWholesaler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(string id, CreateFuelViewModel viewModel)
        {
            if (fuelProvider.FindByReference(id) == null)
            {
                return HttpNotFound();
            }

            viewModel.FuelWholesalers = fuelWholesalerProvider.FindAll();

            if (viewModel.SelectedFuelWholesaler != null && viewModel.SelectedFuelWholesaler != "")
            {
                if (int.TryParse(viewModel.SelectedFuelWholesaler, out int wholesalerId))
                {
                    viewModel.Fuel.FuelWholesalerId = wholesalerId;
                }
            }

            if (viewModel.SelectedType != null && viewModel.SelectedType != "")
            {
                if (Enum.TryParse(viewModel.SelectedType, out FuelType fuelType))
                {
                    viewModel.Fuel.Type = fuelType;
                }
            }

            if (ModelState.IsValid)
            {
                viewModel.Fuel.Reference = id;
                fuelProvider.Update(viewModel.Fuel);
                return RedirectToAction("List");
            }

            return View(viewModel);
        }

        // GET: FuelWholesaler/Delete/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Delete(string id)
        {
            Fuel fuel = fuelProvider.FindByReference(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }

            return View(fuel);
        }

        // POST: FuelWholesaler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult DeleteConfirmed(string id)
        {
            Fuel fuel = fuelProvider.FindByReference(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }

            fuelProvider.Delete(id);
            return RedirectToAction("List");
        }
    }
}
