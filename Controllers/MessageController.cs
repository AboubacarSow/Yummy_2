using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class MessageController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: Message
        public ActionResult Index()
        {
            return View(_dbContext.Messages.ToList());
        }
        public ActionResult SetAsRead(int id)
        {
            var model = _dbContext.Messages.FirstOrDefault(m=>m.MessageId == id);
            model.IsRead = true;    
            _dbContext.SaveChanges();   
            return RedirectToAction("Index"); 
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Messages.Remove(_dbContext.Messages.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}