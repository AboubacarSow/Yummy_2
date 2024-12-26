using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ChefSocialMediaController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: ChefSocialMedia
        public ActionResult Index()
        {
            return View(_dbContext.ChefSocials.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ChefSocial social)
        {
            _dbContext.ChefSocials.Add(social);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}