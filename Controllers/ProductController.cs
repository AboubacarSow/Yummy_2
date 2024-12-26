using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ProductController : Controller
    {
        YummyDbContext _dbContext= new YummyDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(_dbContext.Products.ToList());
        }
        private void GetCategory()
        {
            ViewBag.Category = (from c in _dbContext.Categories
                                select new SelectListItem
                                {
                                    Value = c.CategoryId.ToString(),
                                    Text = c.CategoryName,
                                }).ToList();
        }
        public ActionResult Create()
        {
            GetCategory();  
            return View();
        }
        [HttpPost]  
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                GetCategory();
                return View(product);
                
            }
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            GetCategory();
            return View(_dbContext.Products.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            var value=_dbContext.Products.FirstOrDefault(p=>p.ProductId == product.ProductId);
            if (!ModelState.IsValid)
            {
                GetCategory();  
                return View(product);
            }
            var category=_dbContext.Categories.FirstOrDefault(p=>p.CategoryId == product.CategoryId);
            value.Category=category;    
            value.ProductName = product.ProductName;    
            value.Price = product.Price;    
            value.ImageUrl = product.ImageUrl;  
            value.CategoryId = product.CategoryId;
            value.Ingredients = product.Ingredients;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Products.Remove(_dbContext.Products.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}