using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers.User
{
    [Authorize(Roles ="Trainee")]
    public class TraineeUserController : Controller
    {
        // GET: TraineeUser
        dbTrainningProEntities1 db = new dbTrainningProEntities1();

        public ActionResult TraineeProfile(String userName)
        {
            if(!String.IsNullOrEmpty(userName))
            {
                var trainer = db.Trainees.Where(t => t.userName.Equals(userName)).ToList();
                if(trainer.Count>0)
                {
                    var id = trainer.ElementAt(0).TraineeID;
                    var path = "Details/" + id;
                    return RedirectToAction(path, "Trainees");
                }
            }
            return HttpNotFound();
        }

        public ActionResult GetAssignCourse(String userName)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                var trainer = db.Trainees.Where(t => t.userName.Equals(userName)).ToList();
                if (trainer.Count > 0)
                {
                    var id = trainer.ElementAt(0).TraineeID;
                    var traineeCourses = db.TraineeCourses.Where(tc => tc.TraineeID == id).ToList();
                    return View(traineeCourses);
                }
            }
            return HttpNotFound();

        }
    }

    
}