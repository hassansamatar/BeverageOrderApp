using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            IEnumerable<Category> categoryList = _db.Categories;

            return View(categoryList);
        }
     

        //Get
        public IActionResult Upsert(int? Id)
        {
            Product product = new Product();
            IEnumerable<SelectListItem> categoryList = _db.Categories.Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }) ;
            IEnumerable<SelectListItem> beverageList = _db.BeverageTypes.Select(
               u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString(),
               });
                  
            if (Id == null | Id == 0)
            {
                // Create new Product
                ViewBag.categoryList = categoryList;
                ViewBag.beverageList =beverageList;
                return View(product);
            }
            else
            {
                //Update Product
            }
          
            return View(product);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj, IFormFile? file)
        {
           if (ModelState.IsValid)
            {
                //  _db.Categories.Update(obj);
                string wwwrootPath = _hostEnvironmet.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads= Path.Combine(wwwrootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);
                    using (var fileStreams =new FileStream(Path.Combine(uploads, file+extension
                        ), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.ImageUrl = @"\images\products" + fileName + extension;
                }
                _db.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product  Created successfully";
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
          
            var category = _db.Categories.Find(Id);
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
            var obj = _db.Categories.Find(Id);
            if(Id == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

            
        }
    }
}
