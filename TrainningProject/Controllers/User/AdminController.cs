using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        
        // GET: Admin
        private dbTrainningProEntities1 db = new dbTrainningProEntities1();
        public ActionResult Index()
        {

            return View();
        }
         
        public ActionResult RegisterAccount()
        {
            return View();
        }

        public ActionResult TrainerAccount()
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            ViewBag.User = userManager.Users.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult RegisterAccount(Account acc)
        {
            if (ModelState.IsValid)
            {
                if (!acc.Password.Equals(acc.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Confirm password not math");

                }
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = acc.UserName };
                IdentityResult result = userManager.Create(user, acc.Password);
                userManager.AddToRole(user.Id, "TrainningStaff");

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot create user");
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(acc);
            }

        }


    }
}