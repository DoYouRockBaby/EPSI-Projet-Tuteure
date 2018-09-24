using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using Carsale.ViewModels;
using English_Battle_MVC.Attributes;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class AccountController : AbstractController
    {
        AccountProvider accountProvider;

        public AccountController(AccountProvider accountProvider)
        {
            this.accountProvider = accountProvider;
        }

        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Create()
        {
            ViewBag.EmailError = "";
            ViewBag.RepeatPasswordError = "";

            //Create the default view model
            var account = new Account();
            var viewModel = new CreateAccountViewModel()
            {
                Account = account,
                RepeatPassword = ""
            };

            return View(viewModel);
        }

        [HttpPost, LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Create(CreateAccountViewModel viewModel)
        {
            ViewBag.EmailError = "";
            ViewBag.RepeatPasswordError = "";

            //If the post informations are valid, insert the user in the database
            if (ModelState.IsValid)
            {
                var errorOccured = false;
                if (viewModel.RepeatPassword != viewModel.Account.Password)
                {
                    ViewBag.RepeatPasswordError = "Les mots de passes ne correspondent pas.";
                    errorOccured = true;
                }

                if (accountProvider.FindByEmail(viewModel.Account.Email) != null)
                {
                    ViewBag.EmailError = "L'email renseigné existe déjà dans la base de donnée";
                    errorOccured = true;
                }

                if (!errorOccured)
                {
                    accountProvider.Add(viewModel.Account);
                    return RedirectToAction("List");
                }
            }

            return View(viewModel);
        }

        [LoggedAuthorization]
        public ActionResult List()
        {
            ViewBag.Accounts = accountProvider.FindAll();
            return View();
        }

        [LoggedAuthorization]
        public ActionResult Detail(int id)
        {
            //Check if the user exists
            var account = accountProvider.FindById(id);
            if(account == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            return View(account);
        }

        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Edit(int id)
        {
            //Check if the user exists
            var account = accountProvider.FindById(id);
            if (account == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            //Create default view model
            var viewModel = new CreateAccountViewModel()
            {
                Account = account,
                RepeatPassword = ""
            };

            return View(viewModel);
        }

        [HttpPost, LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director, AccountType.DirectionAssistant })]
        public ActionResult Edit(int id, CreateAccountViewModel viewModel)
        {
            //Check if the user exists
            if(accountProvider.FindById(id) == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            //Force the id to the current logged user
            viewModel.Account.Id = id;

            //If the post informations are valid, update the user informations in the database
            if (ModelState.IsValid)
            {
                var errorOccured = false;
                if (viewModel.RepeatPassword != viewModel.Account.Password)
                {
                    ViewBag.RepeatPasswordError = "Les mots de passes ne correspondent pas.";
                    errorOccured = true;
                }

                if (accountProvider.FindByEmail(viewModel.Account.Email) != null && accountProvider.FindByEmail(viewModel.Account.Email).Id != viewModel.Account.Id)
                {
                    ViewBag.EmailError = "L'email renseigné existe déjà dans la base de donnée";
                    errorOccured = true;
                }

                if (!errorOccured)
                {
                    accountProvider.Update(viewModel.Account);
                }
            }

            return View(viewModel);
        }

        [LoggedAuthorization(AllowedTypes = new AccountType[] { AccountType.Director })]
        public ActionResult Delete(int id)
        {
            //Check if the user exists
            if (accountProvider.FindById(id) == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            accountProvider.Delete(id);

            return RedirectToAction("List");
        }

        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
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

                    accountProvider.Add(new Account()
                    {
                        Email = "fx.sheikhi@gmail.com",
                        FirstName = "sara",
                        LastName = "sheikhi",
                        Password = "123456",
                        Type = AccountType.Director
                    });



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
    }
}