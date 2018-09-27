using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Part = Carsale.DAO.Models.Part;

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
            Part part = partProvider.FindById(id);
            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        // POST: Part/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Edit(int id, [Bind(Include = "Name,Description,Price")] Part part)
        {
            if (partProvider.FindById(id) == null)
            {
                return HttpNotFound();
            }

            part.Id = id;

            if (ModelState.IsValid)
            {
                partProvider.Update(part);
                return RedirectToAction("List");
            }

            return View(part);
        }

        // GET: Part/Delete/5
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult Delete(int id)
        {
            Part part = partProvider.FindById(id);
            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        // POST: Part/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.MaintainVehicleManager })]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = partProvider.FindById(id);
            if (part == null)
            {
                return HttpNotFound();
            }

            partProvider.Delete(id);
            return RedirectToAction("List");
        }
    }
}
