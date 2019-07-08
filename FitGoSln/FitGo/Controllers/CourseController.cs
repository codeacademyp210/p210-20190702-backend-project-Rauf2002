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
    public class CourseController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Course
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Course.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }


        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Duration,Price,Description,Photo")] Course course, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                course.Photo = photoName;
                db.Course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Course course = db.Course.Find(id);
                if (course == null)
                {
                    return HttpNotFound();
                }
                return View(course);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Duration,Price,Description,Photo")] Course course, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                course.Photo = photoName;
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int Id)
        {
            Models.Course foundCourse = db.Course.FirstOrDefault(c => c.Id == Id);

            if (foundCourse != null)
            {
                db.Course.Remove(foundCourse);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Course");
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
