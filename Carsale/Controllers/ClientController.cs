using Carsale.DAO;
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
  //  [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.NewVehicleTrader, AccountType.OldVehicleTrader, AccountType.AccountingDepartmentManager })]
    public class ClientController : Controller
    {
        ClientProvider clientProvider;
        CarsaleContext db = new CarsaleContext();


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

        public ActionResult AddClient()
        {
            return View();
        }
        //Créer une action ajouter un client dans le controlleur
        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {

                db.Clients.Add
                    (new DAO.Models.Client()
                    {

                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        SIRET = client.SIRET,
                        Name = client.Name,
                        Description = client.Description,
                        Address1 = client.Address1,
                        Address2 = client.Address2,
                        ZipCode = client.ZipCode,
                        Country = client.Country

                    });
                db.SaveChanges();
                ViewBag.Error = "Data Added Success!";
                return View();
            }
            ViewBag.Error = "Error Data Is Not Match!";
            return View();
        }
        ////If the post informations are valid, insert the user in the database
        //    if (ModelState.IsValid)
        //    {
        //        var errorOccured = false;
        //        if (viewModel.RepeatPassword != viewModel.Account.Password)
        //        {
        //            ViewBag.RepeatPasswordError = "Les mots de passes ne correspondent pas.";
        //            errorOccured = true;
        //        }

        //        if (accountProvider.FindByEmail(viewModel.Account.Email) != null)
        //        {
        //            ViewBag.EmailError = "L'email renseigné existe déjà dans la base de donnée";
        //            errorOccured = true;
        //        }

        //        if (!errorOccured)
        //        {
        //            accountProvider.Add(viewModel.Account);
        //            return RedirectToAction("List");
        //        }
        //    }

        //    return View(viewModel);
    }
}
