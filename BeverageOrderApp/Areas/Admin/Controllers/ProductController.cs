using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using BeverageOrderApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BeverageOrderApp.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironmet;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
         
            _hostEnvironmet = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Products;

            return View(productList);

            return View();
        }


        //// Get
        // public IActionResult Upsert(int? Id)
        // {
        //     // ProductVM productVM = new();
        //     Product product = new Product();
        //     //IEnumerable<SelectListItem> additionList = _db.Additions.Select(
        //     //    u => new SelectListItem
        //     //    {
        //     //        Text = u.Name,
        //     //        Value = u.Id.ToString(),
        //     //    }) ;

        //     if (Id == null | Id == 0)
        //     {
        //         // Create new Product
        //         //  ViewBag.additionList = additionList;


        //         return View(product);
        //     }
        //     else
        //     {
        //         //Update Product
        //         product = _db.Products.FirstOrDefault(p => p.Id == Id);
        //         return View(product);

        //     }

        // }

        // //Post
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Upsert(Product obj)
        // {
        //    if (ModelState.IsValid)
        //     {
        //         //  _db.Categories.Update(obj);
        //         //string wwwrootPath = _hostEnvironmet.WebRootPath;
        //         //if(file != null)
        //         //{
        //         //    string fileName = Guid.NewGuid().ToString();
        //         //    var uploads= Path.Combine(wwwrootPath, @"images\products");
        //         //    var extension = Path.GetExtension(file.FileName);
        //         //    using (var fileStreams =new FileStream(Path.Combine(uploads, file+extension
        //         //        ), FileMode.Create))
        //         //    {
        //         //        file.CopyTo(fileStreams);
        //         //    }
        //         //    obj.ImageUrl = @"\images\products" + fileName + extension;
        //         //}
        //         _db.Add(obj);
        //         _db.SaveChanges();
        //         TempData["success"] = "Product  Created successfully";
        //         return RedirectToAction("Index");
        //     }
        //     return View(obj); 
        // }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //Get
        public IActionResult Edit(int? Id)
        {
            if (Id == null | Id == 0)
            {
                return NotFound();
            }

            var product = _db.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product Edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Delete
        //Get
        public IActionResult Delete(int? Id)
        {
            if (Id == null | Id == 0)
            {
                return NotFound();
            }
          
            var category = _db.Products.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Products.Find(Id);
            if(Id == null)
            {
                return NotFound();
            }
                _db.Products.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");

            
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {

            var productList = _db.Products; 
           
            return Json(new { data = productList });
        }
        #endregion
    }

}
