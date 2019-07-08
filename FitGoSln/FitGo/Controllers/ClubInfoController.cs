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
    public class ClubInfoController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ClubInfo
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.ClubInfo.FirstOrDefault());
            }
            return RedirectToAction("LogIn", "Home");
        }

        // GET: ClubInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubInfo clubInfo = db.ClubInfo.Find(id);
            if (clubInfo == null)
            {
                return HttpNotFound();
            }
            return View(clubInfo);
        }

        // GET: ClubInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ClubInfo clubInfo = db.ClubInfo.Find(id);
                if (clubInfo == null)
                {
                    return HttpNotFound();
                }
                return View(clubInfo);
            }
            return RedirectToAction("LogIn", "Home");
        }

        // POST: ClubInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Address,City,Pincode,Fax,Website,Photo")] ClubInfo clubInfo, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                clubInfo.Photo = photoName;
                db.Entry(clubInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubInfo);
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
