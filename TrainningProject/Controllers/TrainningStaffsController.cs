using Antlr.Runtime.Misc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    [Authorize]
    public class TrainningStaffsController : Controller
    {
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: TrainningStaffs
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.TrainningStaffs.ToList());
            }
            return HttpNotFound();
        }

        // GET: TrainningStaffs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainningStaff trainningStaff = db.TrainningStaffs.Find(id);
            if (trainningStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainningStaff);
        }

        // GET: TrainningStaffs/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return HttpNotFound();
        }

        // POST: TrainningStaffs/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UserName,Email")] TrainningStaff trainningStaff)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    var staff = db.TrainningStaffs.Find(trainningStaff.ID);
                    if (staff == null)
                    {
                        var staffUserName = db.TrainningStaffs.Where(ts => ts.UserName.Equals(trainningStaff.UserName)).ToList();
                        if (staffUserName.Count() <= 0)
                        {
                            db.TrainningStaffs.Add(trainningStaff);
                            db.SaveChanges();
                            AuthenController.CreateAccount(trainningStaff.UserName, "123456789", "TrainningStaff");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "User existed");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "ID existed");
                    }
                }


                return View(trainningStaff);
            }
            return HttpNotFound();
        }

        // GET: TrainningStaffs/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("TrainningStaff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TrainningStaff trainningStaff = db.TrainningStaffs.Find(id);
                if (trainningStaff == null)
                {
                    return HttpNotFound();
                }
                return View(trainningStaff);
            }
            return HttpNotFound();
        }

        // POST: TrainningStaffs/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UserName,Email")] TrainningStaff trainningStaff)
        {
            if (User.IsInRole("Admin") || User.IsInRole("TrainningStaff"))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(trainningStaff).State = EntityState.Modified;
                    db.SaveChanges();
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        return RedirectToAction("Details" + "/" + trainningStaff.ID);
                    }
                }
                return View(trainningStaff);
            }
            return HttpNotFound();
        }

        // GET: TrainningStaffs/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TrainningStaff trainningStaff = db.TrainningStaffs.Find(id);
                if (trainningStaff == null)
                {
                    return HttpNotFound();
                }
                return View(trainningStaff);
            }
            return HttpNotFound();
        }

        // POST: TrainningStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin"))
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                TrainningStaff trainningStaff = db.TrainningStaffs.Find(id);
                var user = userManager.FindByName(trainningStaff.UserName);
                AuthenController.RemoveAccount(user);
                db.TrainningStaffs.Remove(trainningStaff);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
