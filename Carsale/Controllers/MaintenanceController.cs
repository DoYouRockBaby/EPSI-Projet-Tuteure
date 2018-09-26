using Carsale.ViewModels;
using System.Web.Mvc;

namespace Carsale.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance/List
        public ActionResult List()
        {
            return View();
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult Create(CreateMaintenanceViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
