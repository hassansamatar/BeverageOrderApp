using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeverageOrderApp.Controllers
{
    [Area("Admin")]
    public class AdditionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdditionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Addition> additionList = _db.Additions;

            return View(additionList);
        }
        //Get
        public IActionResult Create()
        {
               return View();
        }
    
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Addition obj)
        {
            if (ModelState.IsValid)
            {
                _db.Additions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Addition Created successfully";
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
          
            var addition = _db.Additions.Find(Id);
            if (addition== null)
            {
                return NotFound();
            }
            return View(addition);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Addition obj)
        {
           if (ModelState.IsValid)
            {
                _db.Additions.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Addition Edited successfully";
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
           
            var category = _db.Additions.Find(Id);
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
            var obj = _db.Additions.Find(Id);
            if(Id == null)
            {
                return NotFound();
            }
                _db.Additions.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

            
        }
    }
}
