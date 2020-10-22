using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    public class TrainningStaffUserController : Controller
    {
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();
        // GET: TrainningStaffUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategories()
        {
            return RedirectToAction("Index", "Categories");
        }

        public ActionResult GetTopic()
        {
            return RedirectToAction("Index", "Topics");
        }

        public ActionResult GetAssign()
        {
            return RedirectToAction("GetCategories", "Share");
        }

        public ActionResult GetCourses()
        {
            return RedirectToAction("Index", "Courses");
        }
        public ActionResult GetTrainees()
        {
            return RedirectToAction("Index", "Trainees");
        }
       
        
        public ActionResult GetProfileUser(String userName)
        {
            var user = db.TrainningStaffs.Where(ts => ts.UserName == userName).ToList();
            if(user.Count>0)
            {
                var id = user.ElementAt(0).ID;
                var path = "Details/" + id;
                return RedirectToAction(path, "TrainningStaffs");
            }
            return HttpNotFound();
        }
        
    }
}