using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    [Authorize]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        
        // GET: Admin
        private dbTrainningProEntities2 db = new dbTrainningProEntities2();
        public ActionResult Index()
        {

            return View();
        }
         public ActionResult GetTrainingStaff()
         {
            
            return RedirectToAction("Index","TrainningStaffs");
         }

        public ActionResult GetTrainers()
        {
            return RedirectToAction("Index", "Trainers");
        }
       
    }
}