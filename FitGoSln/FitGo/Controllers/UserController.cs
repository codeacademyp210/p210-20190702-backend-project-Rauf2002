using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitGo.Models;

namespace FitGo.Controllers
{
    public class UserController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: User
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Users.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult UserTable()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Users.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult Details(int id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Users.FirstOrDefault(u => u.Id == id));
            }
            return RedirectToAction("LogIn", "Home");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View();
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Number,Gender,Address,City,Pincode,Country")] Users users, HttpPostedFileBase Photo)
        {

            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                users.Photo = photoName;
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Users users = db.Users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Number,Gender,Address,City,Pincode,Country")] Users users, HttpPostedFileBase Photo)
        {

            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                users.Photo = photoName;
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int Id)
        {
            Models.Users foundUser = db.Users.FirstOrDefault(u => u.Id == Id);

            if (foundUser != null)
            {
                db.Users.Remove(foundUser);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
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
