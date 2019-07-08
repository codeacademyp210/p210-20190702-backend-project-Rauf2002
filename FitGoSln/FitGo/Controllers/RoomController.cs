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
    public class RoomController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Room
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Room.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Room room = db.Room.Find(id);
                if (room == null)
                {
                    return HttpNotFound();
                }
                return View(room);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }


        public ActionResult Delete(int Id)
        {
            Models.Room foundRoom = db.Room.FirstOrDefault(r => r.Id == Id);

            if (foundRoom != null)
            {
                db.Room.Remove(foundRoom);
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
