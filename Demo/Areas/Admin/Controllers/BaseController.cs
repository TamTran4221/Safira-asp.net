using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string loginString = HttpContext.Session.GetString("AdminLogin");
            if (loginString == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Account", Action = "Login" })
                );
            }

            base.OnActionExecuting(context);
        }
    }
}
