using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NewWorld.Models;

namespace NewWorld.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User account)
        {
            using (MyWorldEntities dbModel = new MyWorldEntities())
            {
                if (dbModel.User.Any(x => x.Username == account.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exists!";

                }

                else if (dbModel.User.Any(x => x.EmailID == account.EmailID))
                {
                    ViewBag.DuplicateMessage = "Email already exists!";

                }

                else
                {
                    //account.Password = Crypto.HashPassword(account.Password);
                    dbModel.User.Add(account);
                    dbModel.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registration is Successfull";
                }
                

            }
           
            return View();

        }

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login Post
        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            using (MyWorldEntities dbModel = new MyWorldEntities())
            {
                var member = dbModel.User.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
                if (member!=null)
                {
                   
                    Session["UserID"] = member.UserID.ToString();
                    Session["Username"] = member.Username.ToString();
                    return RedirectToActionPermanent("Index","Home");
                   
                    
                }

                else
                {
                    ViewBag.DuplicateMessage = "Wrong Username or Password";

                }

                
                
            }

            return View();

        }
       public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
            
        }

        
        public ActionResult Admin()
        {
            MyWorldEntities db = new MyWorldEntities();
            return View(db.Cause.ToList());

        }

        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            MyWorldEntities db = new MyWorldEntities();

            Cause causeDetail = db.Cause.Find(id);
            if (causeDetail == null)
            {
                return HttpNotFound();
            }
            return View(causeDetail);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyWorldEntities db = new MyWorldEntities();
            Cause causeDetail = db.Cause.Find(id);
            db.Cause.Remove(causeDetail);
            db.SaveChanges();
            return RedirectToAction("Admin","User");
        }



    }

    
}