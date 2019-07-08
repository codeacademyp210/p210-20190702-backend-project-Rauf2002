using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitGo.Models;

namespace FitGo.Controllers
{
    public class CourseSchedController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: CourseSched
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                var courseSched = db.CourseSched.Include(c => c.Course).Include(c => c.Room).Include(c => c.Trainer);
                ViewModelHome model = new ViewModelHome();
                model.Courses = db.Course.ToList();
                model.Rooms = db.Room.ToList();
                model.Trainers = db.Trainer.ToList();
                model.CourseScheds = db.CourseSched.ToList();
                return View(model);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: CourseSched/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Day,Start,Finish,Description,CourseId,RoomId,TrainerId,Status")] CourseSched courseSched)
        {
            if (ModelState.IsValid)
            {
                db.CourseSched.Add(courseSched);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseSched.CourseId);
            ViewBag.RoomId = new SelectList(db.Room, "Id", "Name", courseSched.RoomId);
            ViewBag.TrainerId = new SelectList(db.Trainer, "Id", "Name", courseSched.TrainerId);
            return View(courseSched);
        }

        // GET: CourseSched/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CourseSched courseSched = db.CourseSched.Find(id);
                if (courseSched == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseSched.CourseId);
                ViewBag.RoomId = new SelectList(db.Room, "Id", "Name", courseSched.RoomId);
                ViewBag.TrainerId = new SelectList(db.Trainer, "Id", "Name", courseSched.TrainerId);
                return View(courseSched);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: CourseSched/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Day,Start,Finish,Description,CourseId,RoomId,TrainerId,Status")] CourseSched courseSched)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseSched).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Name", courseSched.CourseId);
            ViewBag.RoomId = new SelectList(db.Room, "Id", "Name", courseSched.RoomId);
            ViewBag.TrainerId = new SelectList(db.Trainer, "Id", "Name", courseSched.TrainerId);
            return View(courseSched);
        }


        public ActionResult Delete(int Id)
        {
            Models.CourseSched foundSched = db.CourseSched.FirstOrDefault(s => s.Id == Id);

            if (foundSched != null)
            {
                db.CourseSched.Remove(foundSched);
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
