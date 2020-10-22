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
    public class TrainerTopicsController : Controller
    {

        private dbTrainningProEntities2 db = new dbTrainningProEntities2();

        // GET: TrainerTopics
        public ActionResult Index()
        {
        

            return RedirectToAction("Index","Share");

        }

        // GET: TrainerTopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerTopic trainerTopic = db.TrainerTopics.Find(id);
            if (trainerTopic == null)
            {
                return HttpNotFound();
            }
            return View(trainerTopic);
        }

        public ActionResult GetTrainerTopics(int? id)
        {
            ViewBag.Courses = db.Courses.Find(id);
            var trainerTopics = db.Topics.Where(t => t.TourseID == id);
            return View(trainerTopics);
        }
        // GET: TrainerTopics/Create
        public ActionResult Create(int? id )
        {
           
            ViewBag.Topic = db.Topics.Find(id);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName");
            return View();
        }

        // POST: TrainerTopics/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TrainerID,TopicID")] TrainerTopic trainerTopic)
        {
            if (ModelState.IsValid)
            {
                db.TrainerTopics.Add(trainerTopic);
                db.SaveChanges();
                var topicID = trainerTopic.TopicID;
                var topic = db.Topics.Find(topicID);
                var course = topic.TourseID;
                return RedirectToAction("GetTrainerTopics"+"/"+course);
            }

            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", trainerTopic.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", trainerTopic.TrainerID);
            return View(trainerTopic);
        }

        // GET: TrainerTopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerTopic trainerTopic = db.TrainerTopics.Find(id);
            if (trainerTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", trainerTopic.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", trainerTopic.TrainerID);
            return View(trainerTopic);
        }

        // POST: TrainerTopics/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrainerID,TopicID")] TrainerTopic trainerTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerTopic).State = EntityState.Modified;
                db.SaveChanges();
                var trainerTopID = trainerTopic.ID;
                var topicID = db.TrainerTopics.Find(trainerTopID).TopicID;
                var course = db.Topics.Find(topicID).TourseID;
                return RedirectToAction("GetTrainerTopics"+"/"+ course);
            }
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", trainerTopic.TopicID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", trainerTopic.TrainerID);
            return View(trainerTopic);
        }

        // GET: TrainerTopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerTopic trainerTopic = db.TrainerTopics.Find(id);
            if (trainerTopic == null)
            {
                return HttpNotFound();
            }
            return View(trainerTopic);
        }

        // POST: TrainerTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            TrainerTopic trainerTopic = db.TrainerTopics.Find(id);
            var topicID = trainerTopic.TopicID;
            var course = db.Topics.Find(topicID).TourseID;
            db.TrainerTopics.Remove(trainerTopic);
            db.SaveChanges();
            return RedirectToAction("GetTrainerTopics" + "/" + course);
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
