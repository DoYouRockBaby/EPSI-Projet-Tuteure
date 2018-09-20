using Carsale.DAO;
using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class HomeController : Controller
    {
        CarsaleContext db = new CarsaleContext();
        public ActionResult Index()
        {
            return View();
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