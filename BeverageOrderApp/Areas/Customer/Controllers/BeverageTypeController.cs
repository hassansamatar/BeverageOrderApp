using BeverageOrderApp.Data;
using BeverageOrderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeverageOrderApp.Controllers
{
    [Area("Customer")]
    public class BeverageTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BeverageTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<BeverageType> typeList = _db.BeverageTypes;

            return View(typeList);
        }
        //Get
        public IActionResult Create()
        {
               return View();
        }
    
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeverageType obj)
        {
            if (ModelState.IsValid)
            {
                _db.BeverageTypes.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Type Created successfully";
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
            var type = _db.BeverageTypes.Find(Id);
            if (type == null)
            {
                return NotFound();
            }
            return View(type);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BeverageType obj)
        {
           if (ModelState.IsValid)
            {
                _db.BeverageTypes.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Type Edited successfully";
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
            var type = _db.BeverageTypes.Find(Id);
            if (type == null)
            {
                return NotFound();
            }
            return View(type);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.BeverageTypes.Find(Id);
            if(Id == null)
            {
                return NotFound();
            }
                _db.BeverageTypes.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Type Deleted successfully";
            return RedirectToAction("Index");
           
          
        }
    }
}
