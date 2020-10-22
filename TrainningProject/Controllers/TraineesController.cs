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
    public class TraineesController : Controller
    {

        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: Trainees
        public ActionResult Index()
        {
            if(User.IsInRole("TrainningStaff"))
            {
                return View(db.Trainees.ToList());
            }
            return HttpNotFound();
            
        }

        // GET: Trainees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: Trainees/Create
        public ActionResult Create()
        {
            if(User.IsInRole("TrainningStaff"))
            {
                return View();
            }
            return HttpNotFound();

        }

        // POST: Trainees/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeID,TraineeName,userName,ProgramLanguage,TOEIC,Department,Location,dob,Education,Phone")] Trainee trainee)
        {
            if (User.IsInRole("TrainningStaff"))
            {
                if (ModelState.IsValid)
                {
                    var id = db.Trainees.Find(trainee.TraineeID);
                    if (id == null)
                    {
                        var userName = db.Trainees.Where(t => t.userName.Equals(trainee.userName)).ToList();
                        if (userName.Count() <= 0)
                        {
                            db.Trainees.Add(trainee);
                            db.SaveChanges();
                            AuthenController.CreateAccount(trainee.userName, "12345678", "Trainee");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "User Name existed");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "ID existed");
                    }
                }

                return View(trainee);
            }
            return HttpNotFound();
        }

        // GET: Trainees/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("TrainningStaff") || User.IsInRole("Trainee"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Trainee trainee = db.Trainees.Find(id);
                if (trainee == null)
                {
                    return HttpNotFound();
                }
                return View(trainee);
            }
            return HttpNotFound();
            
        }

        // POST: Trainees/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeID,TraineeName,userName,ProgramLanguage,TOEIC,Department,Location,dob,Education,Phone")] Trainee trainee)
        {
            if (User.IsInRole("TrainningStaff") || User.IsInRole("Trainee"))
            {

                if (ModelState.IsValid)
                {
                    db.Entry(trainee).State = EntityState.Modified;
                    db.SaveChanges();
                    if (User.IsInRole("Trainee"))
                    {
                        return RedirectToAction("Details" + "/" + trainee.TraineeID);
                    }

                    return RedirectToAction("Index");
                }
                return View(trainee);
            }
            return HttpNotFound();
            
        }

        // GET: Trainees/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("TrainningStaff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Trainee trainee = db.Trainees.Find(id);
                if (trainee == null)
                {
                    return HttpNotFound();
                }
                return View(trainee);
            }
            return HttpNotFound();
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("TrainningStaff"))
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                Trainee trainee = db.Trainees.Find(id);
                var user = userManager.FindByName(trainee.userName);
                AuthenController.RemoveAccount(user);
                var traieeCourse = db.TraineeCourses.Where(tt => tt.TraineeID == trainee.TraineeID).ToList();
                foreach (var item in traieeCourse)
                {
                    db.TraineeCourses.Remove(item);
                    db.SaveChanges();
                }
                db.Trainees.Remove(trainee);
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
