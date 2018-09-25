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
    public class HomeController : AbstractController
    {
        AccountProvider accountProvider;

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
    }
}