using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RapNewsManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
                       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string _Email, string _Password, bool _RememberMe = false)
        {
            Models.User objUser = new Models.User();

            if (objUser.IsValid(_Email, _Password, ref objUser))
            {                   
                FormsAuthentication.SetAuthCookie(objUser.Email, objUser.RememberMe);
                return RedirectToAction("UserMainPage", "Users", objUser);
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }

            return View();
        }

    }
}