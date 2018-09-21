
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