using Carsale.DAO;
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
    public class HomeController : Controller
    {
        AccountProvider accountProvider;
        CarsaleContext db = new CarsaleContext();

        public HomeController(AccountProvider accountProvider)
        {
            this.accountProvider = accountProvider;
        }

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            ViewBag.EmailError = "";
            ViewBag.PasswordError = "";

            if (ModelState.IsValid)
            {
                //Check if the user informations are correct
                var user = accountProvider.FindByEmail(viewModel.Email);
                if (user == null)
                {
                    ViewBag.EmailError = "Le compte n'existe pas";
                    return View();
                }
                else if (user.Password != viewModel.Password)
                {
                    ViewBag.PasswordError = "Mot de passe incorrect";
                    return View();
                }
                else
                {
                    //Log the user
                    Session.Add("User", user);
                    return RedirectToAction("List", "Account");
                }
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sale(Sale modele)
        {
            
            if (ModelState.IsValid)
            {
                db.Sales.Add
                    (new DAO.Models.Sale()
                    {
                        SaleDate = modele.SaleDate,
                        SalePrice = modele.SalePrice
                    });
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Sale()
        {
            return View();
        }

        public ActionResult ShowAllSale()
        {
            var mySaleList = db.Sales.ToList();
            return View(mySaleList);
        }
    }
}