using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
       
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult SignIn(Admin admin, string returnUrl)
        {
            var model=_dbContext.Admins.FirstOrDefault( a=>a.UserName==admin.UserName && a.Password==admin.Password);

            if(model==null)
            {
                ModelState.AddModelError("", "Kullanıcı veya Şifre");
                return View(model);  
            }
            FormsAuthentication.SetAuthCookie(admin.UserName,false);
            Session["currentUser"]=admin.UserName;  
            if(returnUrl!=null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "DashBoard");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("SignIn");
        }
    }
}