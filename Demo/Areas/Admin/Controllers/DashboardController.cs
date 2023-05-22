using Microsoft.AspNetCore.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
