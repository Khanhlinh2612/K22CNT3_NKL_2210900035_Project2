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
    public class COMMENTsController : Controller
    {
        private K22CNT3_NKL_2210900035_Project2Entities db = new K22CNT3_NKL_2210900035_Project2Entities();

        // GET: COMMENTs
        public ActionResult Index()
        {
            var cOMMENTs = db.COMMENTs.Include(c => c.NGUOI_DUNG).Include(c => c.STORY);
            return View(cOMMENTs.ToList());
        }

        // GET: COMMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // GET: COMMENTs/Create
        public ActionResult Create()
        {
            ViewBag.ma_nguoi_dung = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap");
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen");
            return View();
        }

        // POST: COMMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_binh_luan,noi_dung,ngay_binh_luan,ma_nguoi_dung,ma_truyen")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                db.COMMENTs.Add(cOMMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_nguoi_dung = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", cOMMENT.ma_nguoi_dung);
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cOMMENT.ma_truyen);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", cOMMENT.ma_nguoi_dung);
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cOMMENT.ma_truyen);
            return View(cOMMENT);
        }

        // POST: COMMENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_binh_luan,noi_dung,ngay_binh_luan,ma_nguoi_dung,ma_truyen")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", cOMMENT.ma_nguoi_dung);
            ViewBag.ma_truyen = new SelectList(db.STORies, "ma_truyen", "ten_truyen", cOMMENT.ma_truyen);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // POST: COMMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            db.COMMENTs.Remove(cOMMENT);
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
