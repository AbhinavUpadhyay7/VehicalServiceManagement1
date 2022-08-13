using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicalServiceManagement1.Models;
using System.Web.Security;

namespace VehicalServiceManagement1.Controllers
{
 
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberShip model)
        {
            using (var context = new ServiceCenterEntities())
            {
                //bool isValid = context.UserLogin.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                bool isValid = context.UserLogin.Any(x => x.UserName == model.UserName && x.Password == model.Password);



                //bool isValid = false;


                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("index", "SerCenters");
                }


                ModelState.AddModelError("", "Invalid UserName Or Password");
                return View();

            }
            
            
        }

        public ActionResult SignUp()
        {


            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserLogin model)
        {
            using (var context = new ServiceCenterEntities())
            {
                context.UserLogin.Add(model);
                context.SaveChanges();
            }


            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}