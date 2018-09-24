using System.Web.Mvc;

namespace Carsale.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            ViewBag.LoggedUser = Session["User"];
            base.OnActionExecuting(filterContext);
        }
    }
}