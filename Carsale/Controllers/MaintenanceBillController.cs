using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class MaintenanceBillController : AbstractController
    {
        MaintenanceProvider maintenanceProvider;
        MaintenanceBillProvider maintenanceBillProvider;
        ClientProvider clientProvider;

        public MaintenanceBillController(MaintenanceProvider maintenanceProvider, MaintenanceBillProvider maintenanceBillProvider, ClientProvider clientProvider)
        {
            this.maintenanceProvider = maintenanceProvider;
            this.maintenanceBillProvider = maintenanceBillProvider;
            this.clientProvider = clientProvider;
        }

        // GET: Bill
        public ActionResult ListUnbilledMaintenances()
        {
            return View(maintenanceProvider.FindAllUnbilled());
        }

        // GET: Bill/ListPaid
        public ActionResult ListPaid()
        {
            return View(maintenanceBillProvider.FindAllPaid());
        }

        // GET: Bill/ListUnpaid
        public ActionResult ListUnpaid()
        {
            return View(maintenanceBillProvider.FindAllUnpaid());
        }

        // GET: Bill/Create
        public ActionResult Create(int id)
        {
            var maintenance = maintenanceProvider.FindById(id);
            if (maintenance == null)
            {
                return new HttpNotFoundResult("L'entretient n'existe pas.");
            }

            var viewModel = new CreateMaintenanceBillViewModel()
            {
                Clients = clientProvider.FindAll(),
                Maintenance = maintenance
            };

            return View(viewModel);
        }

        // POST: Bill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CreateMaintenanceBillViewModel viewModel)
        {
            var maintenance = maintenanceProvider.FindById(id);
            if (maintenance == null)
            {
                return new HttpNotFoundResult("L'entretient n'existe pas.");
            }

            viewModel.Clients = clientProvider.FindAll();
            viewModel.MaintenanceBill = viewModel.MaintenanceBill ?? new MaintenanceBill();

            if (viewModel.SelectedClient != null && viewModel.SelectedClient != "")
            {
                if (int.TryParse(viewModel.SelectedClient, out int clientId))
                {
                    viewModel.MaintenanceBill.ClientId = clientId;
                }
            }

            viewModel.MaintenanceBill.MaintenanceId = id;
            viewModel.MaintenanceBill.Status = MaintenanceBillStatus.Unpaid;
            viewModel.MaintenanceBill.Date = DateTime.Now;

            if(ModelState.IsValid)
            {
                maintenanceBillProvider.Add(viewModel.MaintenanceBill);
                return RedirectToAction("ListUnpaid");
            }

            return View(viewModel);
        }

        // POST: Bill/PayBill/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayBill(int id)
        {
            var bill = maintenanceBillProvider.FindById(id);
            if (bill == null)
            {
                return new HttpNotFoundResult("La facture n'existe pas.");
            }

            bill.Status = MaintenanceBillStatus.Paid;
            maintenanceBillProvider.Update(bill);

            return RedirectToAction("ListPaid");
        }
    }
}
