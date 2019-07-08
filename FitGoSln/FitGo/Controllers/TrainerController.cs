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
    public class TrainerController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Trainer
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Trainer.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }


        // POST: Trainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainer.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Trainer trainer = db.Trainer.Find(id);
                if (trainer == null)
                {
                    return HttpNotFound();
                }
                return View(trainer);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }


        public ActionResult Delete(int Id)
        {
            Models.Trainer foundTrainer = db.Trainer.FirstOrDefault(t => t.Id == Id);

            if (foundTrainer != null)
            {
                db.Trainer.Remove(foundTrainer);
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
