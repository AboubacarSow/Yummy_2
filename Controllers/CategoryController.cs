using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class CategoryController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: Category
        public ActionResult Index()
        {
            return View(_dbContext.Categories.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            _dbContext.Categories.Add(category);    
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Categories.FirstOrDefault(c=>c.CategoryId==id)); 
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            var value=_dbContext.Categories.FirstOrDefault(c=>c.CategoryId == category.CategoryId);
            value.CategoryName = category.CategoryName; 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}