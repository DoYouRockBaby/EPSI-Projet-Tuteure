using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager, AccountType.MaintenanceAgent })]
    public class PartController : AbstractController
    {
        PartProvider partProvider;

        public PartController(PartProvider partProvider)
        {
            this.partProvider = partProvider;
        }

        // GET: Part
        public ActionResult List()
        {
            return View(partProvider.FindAll());
        }

        // GET: Part/Create
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Part/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Create([Bind(Include = "Name,Description,Price")] Part part)
        {
            if(ModelState.IsValid)
            {
                partProvider.Add(part);
                return RedirectToAction("List");
            }

            return View(part);
        }

        // GET: Part/Edit/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Part/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(int id, [Bind(Include = "Description,Price")] Part part)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Part/Delete/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Part/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
