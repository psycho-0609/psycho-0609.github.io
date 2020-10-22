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
    [Authorize]
    public class ShareController : Controller
    {
        // GET: Share
        
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();
        public ActionResult GetCategories()
        {
            var cate = db.Categories.ToList();
            return View(cate);
        }

        public ActionResult GetCourse(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            var course = db.Courses.Where(c => c.CategoryID == id).ToList();
            return View(course);
        }
        public ActionResult ChangePassword(String userName)
        {
            ViewBag.UserName = userName;
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Account acc, String oldPass)
        {
            ViewBag.UserName = acc.UserName;
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.FindByName(acc.UserName);
                if (user != null)
                {

                    if (CheckConfirmPass(acc.Password, acc.ConfirmPassword) == true)
                    {
                        if (AuthenController.UpdateAccount(user, oldPass, acc.Password))
                        {
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Old password incorrect");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Confim password not math");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Not Found userName");
                }
            }
            return View(acc);
        }

        public Boolean CheckConfirmPass(String newPass, String confilm)
        {
            if (newPass.Equals(confilm))
            {
                return true;
            }
            return false;
        }
    }
}