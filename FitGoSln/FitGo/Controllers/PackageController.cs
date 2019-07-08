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
    public class PackageController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Package
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Package.ToList());
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Package/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Start,Finish,Description,Photo,Amount")] Package package, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                package.Photo = photoName;
                db.Package.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(package);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Package package = db.Package.Find(id);
                if (package == null)
                {
                    return HttpNotFound();
                }
                return View(package);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Start,Finish,Description,Photo,Amount")] Package package, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                package.Photo = photoName;
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }


        public ActionResult Delete(int Id)
        {
            Models.Package foundPack = db.Package.FirstOrDefault(s => s.Id == Id);

            if (foundPack != null)
            {
                db.Package.Remove(foundPack);
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
