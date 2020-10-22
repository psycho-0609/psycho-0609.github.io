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
    [Authorize(Roles ="TrainningStaff")]
    public class TraineeCoursesController : Controller
    {

        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: TraineeCourses
        public ActionResult Index()
        {
           

            return RedirectToAction("Index", "Share");
           
        }

        // GET: TraineeCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            return View(traineeCourse);
        }

        public ActionResult GetData(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult GetTraineeCourses(int? id)
        {
            if (id != null)
            {
                if (User.IsInRole("TrainningStaff"))
                {
                    ViewBag.Courses = db.Courses.Find(id);
                    var trainee = db.TraineeCourses.Where(t => t.CourseID == id).ToList();
                    return View(trainee);
                }
            }
            
             return HttpNotFound();
            
        }
        // GET: TraineeCourses/Create
        public ActionResult Create(int? id)
        {

            ViewBag.Courses = db.Courses.Find(id);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName");
            return View();
        }

        // POST: TraineeCourses/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TraineeID,CourseID")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                db.TraineeCourses.Add(traineeCourse);
                db.SaveChanges();
                var course = traineeCourse.CourseID;
                return RedirectToAction("GetTraineeCourses"+"/"+course);
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // POST: TraineeCourses/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TraineeID,CourseID")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeCourse).State = EntityState.Modified;
                db.SaveChanges();
                var course = traineeCourse.CourseID;
                return RedirectToAction("GetTraineeCourses"+"/"+course);
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TrainerName", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            return View(traineeCourse);
        }

        // POST: TraineeCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            var course = traineeCourse.CourseID;
            
            db.TraineeCourses.Remove(traineeCourse);
            db.SaveChanges();
            return RedirectToAction("GetTraineeCourses" + "/" + course); 
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
