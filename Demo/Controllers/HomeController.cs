using Demo.Areas.Admin.Data;
using Demo.Areas.Admin.Models;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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
            List<Product> products = _context.products.ToList(); // Truy vấn danh sách sản phẩm từ cơ sở dữ liệu
            
            Random random = new Random();
            List<Product> shuffledProducts = products.OrderBy(p => random.Next()).ToList(); // Xáo trộn danh sách sản phẩm ngẫu nhiên
            
            ViewBag.Products = shuffledProducts; // Truyền danh sách sản phẩm vào ViewBag
            
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
        public IActionResult Product()
        {
            List<Product> products = _context.products.OrderByDescending(p => p.Id).ToList();
            ViewBag.products = products;
            return View();

        }
        public IActionResult Detail(int id)
        {
            Product product = _context.products.FirstOrDefault(p => p.Id == id); // Truy vấn sản phẩm từ cơ sở dữ liệu

            if (product == null)
            {
                return NotFound(); // Xử lý nếu không tìm thấy sản phẩm với ID đã cho
            }

            return View(product); // Truyền sản phẩm cho View
        }

        public IActionResult Login()
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
                    HttpContext.Session.SetString("MyConnect", JsonConvert.SerializeObject(acc));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register( Account account)
        {
            if (ModelState.IsValid)
            {
                var check = _context.accounts.FirstOrDefault(a => a.Email == account.Email);
                if (check == null)
                {
                    account.Password = GetMD5(account.Password);
                    _context.ChangeTracker.LazyLoadingEnabled = false;
                    _context.accounts.Add(account);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }

        private string GetMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(password);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
 
}