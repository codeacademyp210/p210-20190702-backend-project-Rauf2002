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
    public class CouponController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Coupon
        public ActionResult Index()
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                return View(db.Coupon.ToList());
            }
            return RedirectToAction("LogIn", "Home");
            
        }



        // POST: Coupon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Start,Finish,Description,Photo,Code")] Coupon coupon, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                coupon.Photo = photoName;
                db.Coupon.Add(coupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coupon);
        }

        // GET: Coupon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["isLogin"] != null && (bool)Session["isLogin"] == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Coupon coupon = db.Coupon.Find(id);
                if (coupon == null)
                {
                    return HttpNotFound();
                }
                return View(coupon);
            }
            return RedirectToAction("LogIn", "Home");
            
        }

        // POST: Coupon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Start,Finish,Description,Photo,Code")] Coupon coupon, HttpPostedFileBase Photo)
        {
            string image = "";
            string photoName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Photo.FileName;
            if (ModelState.IsValid)
            {
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                coupon.Photo = photoName;
                db.Entry(coupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coupon);
        }


        public ActionResult Delete(int Id)
        {
            Models.Coupon foundCoupon = db.Coupon.FirstOrDefault(c => c.Id == Id);

            if (foundCoupon != null)
            {
                db.Coupon.Remove(foundCoupon);
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
