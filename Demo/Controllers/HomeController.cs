using Demo.Areas.Admin.Data;
using Demo.Areas.Admin.Models;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
        
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Product> products = _context.products.Take(4).OrderByDescending(p => p.Id).ToList();
            //ViewBag.products = products;
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page.";

            return View();

        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();

        }
        public IActionResult Product ()
        {
            return View();

        }
        public IActionResult Detail(int id)
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                 Account acc = _context.accounts.FirstOrDefault(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password));

                if (acc != null)
                {
                    HttpContext.Session.SetString("AppLogin", JsonConvert.SerializeObject(acc));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            return View(model);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}