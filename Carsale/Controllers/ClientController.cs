using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader, AccountType.AccountingDepartmentManager })]
    public class ClientController : AbstractController
    {
        ClientProvider clientProvider;

        public ClientController(ClientProvider clientProvider)
        {
            this.clientProvider = clientProvider;
        }

        public ActionResult List()
        {
            ViewBag.Clients = clientProvider.FindAll();
            return View();
        }

        public ActionResult Detail(int id)
        {
            //Check if the client exists
            var client = clientProvider.FindById(id);
            if (client == null)
            {
                return new HttpNotFoundResult("Le client n'existe pas.");
            }

            return View(client);
        }
    }
}