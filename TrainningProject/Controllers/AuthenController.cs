using Antlr.Runtime.Misc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    public class AuthenController : Controller
    {
        // GET: Authen
        public ActionResult Index()
        {
            return View();
        }

        public static void CreateAccount(String userName, String password, String role)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(userName);
            manager.Create(user, password);
            manager.AddToRole(user.Id,role);
        }

        public static Boolean UpdateAccount(IdentityUser user, String currentPassword, String newPassword)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            IdentityResult result = manager.ChangePassword(user.Id, currentPassword, newPassword);
            if(result.Succeeded)
            {
                return true;
            }

            return false;
            
        }
      

        public static void RemoveAccount(IdentityUser user)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userRole = manager.GetRoles(user.Id).ToList();
            foreach(var item in userRole)
            {
                manager.RemoveFromRole(user.Id, item);
            }
            var x = manager.FindById(user.Id);
            manager.Delete(x);
            
        }
      
        public ActionResult Login()
        {
            return View();
        }

      

        [HttpPost]

        public ActionResult Login(Account acc)
        {
            
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            if (acc.Password != null || acc.UserName != null)
            {


                var user = manager.Find(acc.UserName, acc.Password);
                if (user != null)
                {
                    var authentacationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authentacationManager.SignIn(new AuthenticationProperties { }, userIdentity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Authen");
        }


       
    }
}