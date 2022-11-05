using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeverageOrderApp.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;

            return View(categoryList);
        }
        //Get
        public IActionResult Create()
        {
               return View();
        }
    
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);   
            
        }

        //Get
        public IActionResult Edit(int? Id)
        {
            if(Id == null | Id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.FirstOrDefault(c => c.Id == Id);
            //var category = _db.Categories.SingleOrDefault(c => c.Id == Id);
            var category = _db.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
           if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited successfully";
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
            //var category = _db.Categories.FirstOrDefault(c => c.Id == Id);
            //var category = _db.Categories.SingleOrDefault(c => c.Id == Id);
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
