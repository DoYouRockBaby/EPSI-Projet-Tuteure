using Carsale.DAO.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace English_Battle_MVC.Attributes
{
    public class LoggedAuthorizationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public AccountType[] AllowedTypes { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["User"] as Account;
            if (user == null)
            {
                //If the user is not logged, redirect him to the connection page
                filterContext.Result = new RedirectResult("/Account/Connect");
            }
            else if(AllowedTypes != null && AllowedTypes.Length > 0 && !AllowedTypes.Contains(user.Type))
            {
                //If the user is logged but dont have the good access rights, send him a 401 error
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}