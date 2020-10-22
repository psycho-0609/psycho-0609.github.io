using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    [Authorize(Roles ="Trainer")]
    public class TrainerUserController : Controller
    {
        
        // GET: TrainerUser
        private dbTrainningProEntities1 db = new dbTrainningProEntities1();
        public ActionResult GetUser(String userName)
        {
            if(!String.IsNullOrEmpty(userName))
            {
                var trainer = db.Trainers.Where(t=>t.UserName.Equals(userName)).ToList();
                if (trainer.Count > 0)
                {
                    var id = trainer.ElementAt(0).TrainerID;
                    return RedirectToAction("Details" + "/" + id, "Trainers");
                }
            }
            return HttpNotFound();
        }

        public ActionResult TrainerAssign(String userName)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                var trainer = db.Trainers.Where(t => t.UserName.Equals(userName)).ToList();
                if (trainer.Count > 0)
                {
                    var id = trainer.ElementAt(0).TrainerID;
                    var topic = db.TrainerTopics.Where(t => t.TrainerID.Equals(id)).ToList();
                    return View(topic);
                }
            }
            return HttpNotFound();
        }
    }
}