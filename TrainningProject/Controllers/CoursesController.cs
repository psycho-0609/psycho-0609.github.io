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
    public class CoursesController : Controller
    {
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: Courses
        public ActionResult Index(String nameSearch)
        {
            var courses = from c in db.Courses
                          select c;
            if(!String.IsNullOrEmpty(nameSearch))
            {
                courses = courses.Where(c => c.CourseName.Contains(nameSearch));
            }
            
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CategoryID,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                var cou = db.Courses.Find(course.CourseID);
                if (cou == null)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Course existed");
                }
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CategoryID,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                var cou = db.Courses.Find(course.CourseID);
                if(cou==null)
                {

                    db.Entry(course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Course ID existed");
                }
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var traineeCourses = db.TraineeCourses.Where(tc => tc.CourseID == id).ToList();
            foreach(var item in traineeCourses)
            {
                db.TraineeCourses.Remove(item);
                db.SaveChanges();
            }
            var topic = db.Topics.Where(t => t.TourseID == id).ToList();
            foreach(var item in topic)
            {
                var trainerTopics = db.TrainerTopics.Where(tt => tt.TopicID == item.TopicID).ToList();
                foreach(var tTopic in trainerTopics)
                {
                    db.TrainerTopics.Remove(tTopic);
                }
                db.Topics.Remove(item);
            }
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
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
