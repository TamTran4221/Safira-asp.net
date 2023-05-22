using Demo.Areas.Admin.Data;
using Demo.Areas.Admin.Models;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo.Areas.Admin.Controllers
{
   
        [Area("Admin")]
        public class AccountController : Controller
        {
            private readonly AppDbContext _context;

            public AccountController(AppDbContext context)
            {
                _context = context;
            }
            public IActionResult Login()
            {
                return View();
            }

            public IActionResult Logout()
            {
                HttpContext.Session.Remove("AdminLogin");
                return RedirectToAction("Login");
            }


            [HttpPost] // POST khi submit form
            public IActionResult Login(Login model)
            {
                if (ModelState.IsValid)
                {
                    Account acc = _context.accounts.FirstOrDefault(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password));

                    if (acc != null)
                    {
                        HttpContext.Session.SetString("AdminLogin", JsonConvert.SerializeObject(acc));
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Tài khoản hoặc mật khẩu không chính xác");
                    }
                }
                return View(model);
            }

        }
    
}
