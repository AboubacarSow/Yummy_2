using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class DashBoardController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();
        // GET: DashBoard
        public ActionResult Index()
        {
            GetDashBoardData();
            return View();
        }

        private void GetDashBoardData()
        {
            ViewBag.soupCount = _dbContext.Products.Count(c => c.Category.CategoryName == "Çorbalar");
            ViewBag.mostExpensiveN = _dbContext.Products.OrderByDescending(p => p.Price).Select(p => p.ProductName).FirstOrDefault();
            ViewBag.mostExpensiveP = _dbContext.Products.OrderByDescending(p => p.Price).Select(p => p.Price).FirstOrDefault();
            ViewBag.lowerpriceN = _dbContext.Products.OrderBy(p => p.Price).Select(p => p.ProductName).FirstOrDefault();
            ViewBag.lowerpriceP = _dbContext.Products.OrderBy(p => p.Price).Select(p => p.Price).FirstOrDefault();
            ViewBag.averagPrice = _dbContext.Products.Average(p => p.Price).ToString();
        }
    }
}