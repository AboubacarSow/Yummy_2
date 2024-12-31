using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ContactController : Controller
    {
        YummyDbContext _dbContext= new YummyDbContext();    
        // GET: Contact
        public ActionResult Index()
        {
            return View(_dbContext.ContactInfos.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.ContactInfos.Remove(_dbContext.ContactInfos.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}