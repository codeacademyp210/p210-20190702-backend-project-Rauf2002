using FitGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FitGo.Controllers
{
    public class HomeController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        public ActionResult Index()
        {

            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                ViewModelHome model = new ViewModelHome();
                model.Courses = db.Course.ToList();
                model.Rooms = db.Room.ToList();
                model.Trainers = db.Trainer.ToList();
                model.CourseScheds = db.CourseSched.ToList();
                model.Users = db.Users.ToList();
                return View(model);
            }
            return RedirectToAction("LogIn");


        }

        public ActionResult LogIn()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LogIn([Bind(Include = "Username,Password")] Admin admin)
        {
            Models.Admin foundAdmin = db.Admin.FirstOrDefault(a => a.Username == admin.Username);

            if (string.IsNullOrEmpty(admin.Username) || string.IsNullOrEmpty(admin.Password))
            {
                Session["loginError"] = "Neither email nor password can be left empty";
                return RedirectToAction("LogIn");
            }

            if (foundAdmin != null)
            {
                if (foundAdmin.Password == Crypto.Hash(admin.Password, "md5"))
                {
                    Session["isLogin"] = true;
                    return RedirectToAction("Index");
                }

            }
            Session["loginError"] = "Either email or password can not be found";

            return RedirectToAction("Index");
        }


        public ActionResult LogOut()
        {
            Session["isLogin"] = null;
            return RedirectToAction("LogIn");
        }



    }
}