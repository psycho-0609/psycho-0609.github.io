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
    public class TrainersController : Controller
    {

        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: Trainers
        public ActionResult Index()
        {
            if (User.IsInRole("Admin")||User.IsInRole("TrainningStaff"))
            {
                return View(db.Trainers.ToList());
            }
            return HttpNotFound();
        }

        // GET: Trainers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin")||User.IsInRole("TrainningStaff"))
            {
                return View();
            }
            return HttpNotFound();
        }

        // POST: Trainers/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerID,TrainerName,Email,UserName,Age,dob,WokingPlace,Phone")] Trainer trainer)
        {
            if (User.IsInRole("Admin")||User.IsInRole("TrainningStaff"))
            {
                if (ModelState.IsValid)
                {
                    var id = db.Trainers.Find(trainer.TrainerID);
                    if (id == null)
                    {
                        var trainerUser = db.Trainers.Where(t => t.UserName.Equals(trainer.UserName)).ToList();
                        if (trainerUser.Count() <= 0)
                        {
                            db.Trainers.Add(trainer);
                            db.SaveChanges();
                            AuthenController.CreateAccount(trainer.UserName, "123456789", "Trainer");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Username existed");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "ID existed");
                    }
                }

                return View(trainer);
            }
            return HttpNotFound();
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(string id)
        {
            if (User.IsInRole("Trainee"))
            {
                return HttpNotFound();
            }
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerID,TrainerName,Email,UserName,Age,dob,WokingPlace,Phone")] Trainer trainer)
        {
            if(User.IsInRole("Trainee"))
            {
                return HttpNotFound();
            }
            
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                if(User.IsInRole("Trainer"))
                {
                        return RedirectToAction("Details" + "/" + trainer.TrainerID);
                }
                 return RedirectToAction("Index");
             }
             return View(trainer);
            
           
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("TrainningStaff"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return HttpNotFound();
                }
                return View(trainer);
            }
            return HttpNotFound();
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (User.IsInRole("Admin")||User.IsInRole("TrainningStaff"))
            {
                Trainer trainer = db.Trainers.Find(id);
                db.Trainers.Remove(trainer);
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
