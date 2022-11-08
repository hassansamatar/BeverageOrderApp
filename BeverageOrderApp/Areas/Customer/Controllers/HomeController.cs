using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using BeverageOrderApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BeverageOrderApp.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,  ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Products;
                   return View(productList);
           

           
        }

        public IActionResult Details(int id)
        {
            //ShoppingCart cartObj = new()
            //{
            //    Count = 1,
            //    Product = _db.Products.FirstOrDefault(x => x.Id == id)

            //};
            //return View(cartObj);
            var product = _db.Products.FirstOrDefault(x => x.Id == id); 
            return View(product);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}