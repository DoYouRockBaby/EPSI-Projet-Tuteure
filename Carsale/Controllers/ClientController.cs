using Carsale.DAO;
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
        CarsaleContext db = new CarsaleContext();


        public ClientController(ClientProvider clientProvider)
        {
            this.clientProvider = clientProvider;
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
