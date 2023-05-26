using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Controllers
{
    public class DefalutController : Controller, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string loginString = HttpContext.Session.GetString("MyConnect");
            if (loginString == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Home", Action = "Login" })
                );
            }

            base.OnActionExecuting(context);
        }
    }
}
