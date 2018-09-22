
using Carsale.DAO.Models;
using Carsale.DAO.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class BrandController : Controller
    {

       private BrandProvider brandProvider;
       public BrandController(BrandProvider brandProvider)
        {
            this.brandProvider = brandProvider;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            ViewBag.LoggedUser = Session["User"];
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Create()
        {
            Brand brand = new Brand();
            return View(brand);
        }
       [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brandProvider.Add(brand);
                return RedirectToAction("Create","Vehicle");
            }
            return View(brand);
        }
    }
}