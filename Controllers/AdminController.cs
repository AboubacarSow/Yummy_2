using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class AdminController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: Admin
        public ActionResult Index()
        {
            return View(_dbContext.Admins.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluşmuştur");
                return View(admin);
            }
            if (admin.ImageFile != null)
            {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveLocation, admin.ImageFile.FileName);
                    admin.ImageFile.SaveAs(fileName);
                    admin.ImageUrl = "/assets/" + admin.ImageFile.FileName;
            }
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _dbContext.Admins.Remove(_dbContext.Admins.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.Admins.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            var value=_dbContext.Admins.FirstOrDefault(a=>a.Id == admin.Id);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluşmuştur");
                return View(admin);
            }
            if (admin.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets\\";
                var fileName = Path.Combine(saveLocation, admin.ImageFile.FileName);
                admin.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/assets/" + admin.ImageFile.FileName;
            }
            value.UserName = admin.UserName;    
            value.Password = admin.Password;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}