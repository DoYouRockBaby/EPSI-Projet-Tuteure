using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager, AccountType.MaintenanceAgent })]
    public class FuelWholesalerController : AbstractController
    {
        FuelWholesalerProvider fuelWholesalerProvider;

        public FuelWholesalerController(FuelWholesalerProvider fuelWholesalerProvider)
        {
            this.fuelWholesalerProvider = fuelWholesalerProvider;
        }

        // GET: FuelWholesaler
        public ActionResult List()
        {
            return View(fuelWholesalerProvider.FindAll());
        }

        // GET: FuelWholesaler/Details/5
        public ActionResult Details(int id)
        {
            FuelWholesaler fuelWholesaler = fuelWholesalerProvider.FindById(id);
            if (fuelWholesaler == null)
            {
                return HttpNotFound();
            }

            return View(fuelWholesaler);
        }

        // GET: FuelWholesaler/Create
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuelWholesaler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create(FuelWholesaler fuelWholesaler)
        {
            if(ModelState.IsValid)
            {
                fuelWholesalerProvider.Add(fuelWholesaler);
                return RedirectToAction("List");
            }
            
            return View(fuelWholesaler);
        }

        // GET: FuelWholesaler/Edit/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(int id)
        {
            FuelWholesaler fuelWholesaler = fuelWholesalerProvider.FindById(id);
            if (fuelWholesaler == null)
            {
                return HttpNotFound();
            }

            return View(fuelWholesaler);
        }

        // POST: FuelWholesaler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(int id, FuelWholesaler fuelWholesaler)
        {
            if (fuelWholesalerProvider.FindById(id) == null)
            {
                return HttpNotFound();
            }

            fuelWholesaler.Id = id;

            if (ModelState.IsValid)
            {
                fuelWholesalerProvider.Update(fuelWholesaler);
                return RedirectToAction("List");
            }

            return View(fuelWholesaler);
        }

        // GET: FuelWholesaler/Delete/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Delete(int id)
        {
            FuelWholesaler fuelWholesaler = fuelWholesalerProvider.FindById(id);
            if (fuelWholesaler == null)
            {
                return HttpNotFound();
            }

            return View(fuelWholesaler);
        }

        // POST: FuelWholesaler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult DeleteConfirmed(int id)
        {
            FuelWholesaler fuelWholesaler = fuelWholesalerProvider.FindById(id);
            if (fuelWholesaler == null)
            {
                return HttpNotFound();
            }

            fuelWholesalerProvider.Delete(id);
            return RedirectToAction("List");
        }
    }
}
