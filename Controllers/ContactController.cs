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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Create(ContactInfo contact)
        {
            _dbContext.ContactInfos.Add(contact);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.ContactInfos.Find(id));
        }
        [HttpPost]
        public ActionResult Update(ContactInfo contact)
        {
            var value=_dbContext.ContactInfos.Find(contact.Id);
            value.Address = contact.Address;    
            value.Email = contact.Email;
            value.PhoneNumber = contact.PhoneNumber;    
            value.MapUrl = contact.MapUrl;  
            value.OpenHours = contact.OpenHours;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}