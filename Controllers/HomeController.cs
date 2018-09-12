using NewWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult StartPetition()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BrowseCause()
        {
            MyWorldEntities db = new MyWorldEntities();
            return View(db.Cause.ToList());
        }

       





        public ActionResult About()
        {
            return View();
        }
       
      

        [HttpGet]
        public ActionResult CreateCause()
        {
            return View();
        }
        //Insert the user_id in the cause table to link the tables with 1 to many relationship 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCause(Cause c)
        {
            var dbModel = new MyWorldEntities();
            int currentSessionId = Convert.ToInt32(Session["UserID"]);
            User currentUser = dbModel.User.Find(currentSessionId);
            c.User = currentUser;
            dbModel.Cause.Add(c);
            dbModel.SaveChanges();

            TempData["message"] = "The cause has been created!";

            return View();
            

        }
       


    }
}