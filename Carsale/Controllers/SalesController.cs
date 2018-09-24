using System.Net;
using System.Web.Mvc;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;

namespace Carsale.Controllers
{
    public class SalesController : AbstractController
    {
        SaleProvider saleProvider = new SaleProvider();

        // GET: Sales
        public ActionResult Index()
        {
            return View(saleProvider.FindAll());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            Sale sale = saleProvider.FindById(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SaleDate,SalePrice")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                saleProvider.Add(sale);
                return RedirectToAction("Index");
            }

            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var oEntity =saleProvider.FindById(id);
            if (oEntity == null)
            {
                return HttpNotFound();
            }
            return View(oEntity);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SaleDate,SalePrice")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                saleProvider.Update(sale);
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = saleProvider.FindById(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            saleProvider.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
