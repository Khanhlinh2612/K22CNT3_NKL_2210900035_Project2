using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_NKL_2210900035_Project2.Models;

namespace K22CNT3_NKL_2210900035_Project2.Controllers
{
    public class CHAPTERsController : Controller
    {
        private K22CNT3_NKL_2210900035_Project2Entities db = new K22CNT3_NKL_2210900035_Project2Entities();

        // GET: CHAPTERs
        public ActionResult Index()
        {
            var cHAPTERs = db.CHAPTERs.Include(c => c.STORY);
            return View(cHAPTERs.ToList());
        }

        // GET: CHAPTERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTERs.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            return View(cHAPTER);
        }

        // GET: CHAPTERs/Create
        public ActionResult Create()
        {
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen");
            return View();
        }

        // POST: CHAPTERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_chuong,so_chuong,ten_chuong,noi_dung,ngay_dang,ma_truyen")] CHAPTER cHAPTER)
        {
            if (ModelState.IsValid)
            {
                db.CHAPTERs.Add(cHAPTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cHAPTER.ma_truyen);
            return View(cHAPTER);
        }

        // GET: CHAPTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTERs.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cHAPTER.ma_truyen);
            return View(cHAPTER);
        }

        // POST: CHAPTERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_chuong,so_chuong,ten_chuong,noi_dung,ngay_dang,ma_truyen")] CHAPTER cHAPTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHAPTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cHAPTER.ma_truyen);
            return View(cHAPTER);
        }

        // GET: CHAPTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAPTER cHAPTER = db.CHAPTERs.Find(id);
            if (cHAPTER == null)
            {
                return HttpNotFound();
            }
            return View(cHAPTER);
        }

        // POST: CHAPTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHAPTER cHAPTER = db.CHAPTERs.Find(id);
            db.CHAPTERs.Remove(cHAPTER);
            db.SaveChanges();
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
