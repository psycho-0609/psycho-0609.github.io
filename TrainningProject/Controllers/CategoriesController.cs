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
    public class CategoriesController : Controller
    {
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: Categories
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                var ca = db.Categories.Where(c => c.Name.Equals(category.Name)).ToList();
                if (ca.Count <= 0)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Category existed");
                }
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
               
            }
            return View(category);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var courses = db.Courses.Where(c => c.CategoryID == id).ToList();
            foreach (var item in courses)
            {
                var traineeCoures = db.TraineeCourses.Where(tc => tc.CourseID == item.CourseID).ToList();
                foreach (var tCourse in traineeCoures)
                {
                    db.TraineeCourses.Remove(tCourse);
                }
                var topics = db.Topics.Where(t => t.TourseID == item.CourseID).ToList();
                foreach (var topic in topics)
                {
                    var trainerTopic = db.TrainerTopics.Where(tt => tt.TopicID == topic.TopicID).ToList();
                    foreach (var tt in trainerTopic)
                    {
                        db.TrainerTopics.Remove(tt);
                    }
                }
                db.Courses.Remove(item);
            }
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
