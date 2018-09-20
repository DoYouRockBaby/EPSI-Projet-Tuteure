using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader, AccountType.AccountingDepartmentManager })]
    public class ClientController : Controller
    {
        ClientProvider clientProvider;

        public ClientController(ClientProvider clientProvider)
        {
            this.clientProvider = clientProvider;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            ViewBag.LoggedUser = Session["User"];
            base.OnActionExecuting(filterContext);
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