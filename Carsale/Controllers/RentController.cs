using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carsale.DAO;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader })]
    public class RentController : AbstractController
    {
        private readonly RentProvider _rentProvider=new RentProvider();
        private readonly ClientProvider _clientProvider=new ClientProvider();
        private readonly VehicleProvider _vehicleProvider=new VehicleProvider();
        private readonly NotificationProvider _notificationProvider = new NotificationProvider();
        // GET: Rent
        public ActionResult Index()
        {
            var rents=_rentProvider.FindAll();
            
            return View(rents);
        }

        // GET: Rent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rent rent = _rentProvider.FindById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rent/Create
        public ActionResult Create()
        {
            var vehicles = _vehicleProvider.FindAll();
            ViewBag.ClientId = new SelectList(_clientProvider.FindAll(), "Id", "FirstName");
            ViewBag.VehicleMatriculation = new SelectList(vehicles.Where(c=>c.Status== StatusVehicle.New), "Matriculation", "Model");
            return View();
        }

        // POST: Rent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleMatriculation,ClientId,StartDate,Price,Distance")] Rent rent)
        {
            var vehicles = _vehicleProvider.FindAll();
            if (ModelState.IsValid)
            {
                var vehicle = _vehicleProvider.FindByMatriculation(rent.VehicleMatriculation);
                vehicle.Status = StatusVehicle.Used;
                _vehicleProvider.Update(vehicle);
                _rentProvider.Add(rent);

                Notification oNotification=new Notification();
                oNotification.Title = "Rent " + vehicle.Matriculation;
                oNotification.Text = "The Rent period of Vehicle with " + vehicle.Matriculation + " is Expired today!";
                DateTime oDate = DateTime.Now;
                var oThreeDatesLater = oDate.AddYears(3);
                oNotification.ShowDate = oThreeDatesLater.ToShortDateString();
                _notificationProvider.Add(oNotification);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientProvider.FindAll(), "Id", "FirstName", rent.ClientId);
            ViewBag.VehicleMatriculation = new SelectList(vehicles.Where(c => c.Status == StatusVehicle.New), "Matriculation", "Model", rent.VehicleMatriculation);
            return View(rent);
        }

        // GET: Rent/Edit/5
        public ActionResult Edit(int? id)
        {
            var vehicles = _vehicleProvider.FindAll();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = _rentProvider.FindById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(_clientProvider.FindAll(), "Id", "FirstName", rent.ClientId);
            ViewBag.VehicleMatriculation = new SelectList(vehicles.Where(c => c.Status == StatusVehicle.New), "Matriculation", "Model", rent.VehicleMatriculation);
            return View(rent);
        }

        // POST: Rent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleMatriculation,ClientId,StartDate,Price,Distance")] Rent rent)
        {
            var vehicles = _vehicleProvider.FindAll();
            if (ModelState.IsValid)
            {
                   _rentProvider.Update(rent);
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_clientProvider.FindAll(), "Id", "FirstName", rent.ClientId);
            ViewBag.VehicleMatriculation = new SelectList(vehicles.Where(c => c.Status == StatusVehicle.New), "Matriculation", "Model", rent.VehicleMatriculation);
            return View(rent);
        }

        // GET: Rent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Rent rent = _rentProvider.FindById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _rentProvider.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
