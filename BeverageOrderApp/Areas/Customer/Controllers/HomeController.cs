﻿using BeverageOrderApp.Data;
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

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Products;
            return View(productList);



        }

        public IActionResult Details2(int id)
        {
           
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult Order(int Id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            return View(product);
        }


        // Detaits2
        public IActionResult Details(int productId)
        {

            ShoppingCart cartObj = new()
            {
                Id = productId,
                Count = 1,
                Product = _db.Products.FirstOrDefault(x => x.Id == productId)
              



        };

          
           
            
     
            // IEnumerable<T> GetAll(Expression<Func<T, bool>> ? filter = null, string? includeProperties = null);
            

            //var additionList =_db.AdditionStores.Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()

            // });

            // ViewBag.additionList =additionList;

            return View(cartObj);
        }

}

        

}