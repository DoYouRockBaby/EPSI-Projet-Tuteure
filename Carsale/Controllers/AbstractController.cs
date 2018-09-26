using Carsale.DAO.Models;
using Carsale.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            var user = Session["User"] as Account;
            ViewBag.LoggedUser = user;
            base.OnActionExecuting(filterContext);


            //Build the main menu items list
            var menuItems = new List<ControllerActionLink>();

            if(user != null)
            {
                switch(user.Type)
                {
                    case AccountType.Director:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Comptes utilisateurs",
                            Controller = "Account",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Comptes clients",
                            Controller = "Client",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Vehicules en vente",
                            Controller = "Vehicle",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Historique des ventes",
                            Controller = "Sale",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Catalogue des pièces",
                            Controller = "Part",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Taux horaires",
                            Controller = "HourlyRate",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Entretients de vehicule",
                            Controller = "Maintenance",
                            Action = "List"
                        });

                        break;
                    case AccountType.NewVehicleTrader:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Comptes clients",
                            Controller = "Client",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Vehicules en vente",
                            Controller = "Vehicle",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Historique des ventes",
                            Controller = "Sale",
                            Action = "List"
                        });

                        break;
                    case AccountType.OldVehicleTrader:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Comptes clients",
                            Controller = "Client",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Vehicules en vente",
                            Controller = "Vehicle",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Historique des ventes",
                            Controller = "Sale",
                            Action = "List"
                        });

                        break;
                    case AccountType.AccountingDepartmentManager:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Gérer les comptes clients",
                            Controller = "Client",
                            Action = "List"
                        });

                        break;
                    case AccountType.MaintainVehicleManager:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Catalogue des pièces",
                            Controller = "Part",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Taux horaires",
                            Controller = "HourlyRate",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Entretients de vehicule",
                            Controller = "Maintenance",
                            Action = "List"
                        });

                        break;
                    case AccountType.MaintenanceAgent:
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Catalogue des pièces",
                            Controller = "Part",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Taux horaires",
                            Controller = "HourlyRate",
                            Action = "List"
                        });

                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Entretients de vehicule",
                            Controller = "Maintenance",
                            Action = "List"
                        });

                        break;
                }

                ViewBag.MenuItems = menuItems;
            }
        }
    }
}