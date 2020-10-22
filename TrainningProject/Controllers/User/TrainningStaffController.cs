using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningProject.Models;

namespace TrainningProject.Controllers
{
    public class TrainningStaffController : Controller
    {
        private dbTrainningProEntities1 db = new dbTrainningProEntities1();
        // GET: TrainningStaff
        public ActionResult Index()
        {

            return View();
        }
    }
}