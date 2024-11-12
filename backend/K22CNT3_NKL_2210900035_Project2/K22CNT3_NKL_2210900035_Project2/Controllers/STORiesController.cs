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
    public class STORiesController : Controller
    {
        private K22CNT3_NKL_2210900035_Project2Entities db = new K22CNT3_NKL_2210900035_Project2Entities();

        // GET: STORies
        public ActionResult Index()
        {
            var sTORies = db.STORies.Include(s => s.NGUOI_DUNG);
            return View(sTORies.ToList());
        }

        // GET: STORies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STORY sTORY = db.STORies.Find(id);
            if (sTORY == null)
            {
                return HttpNotFound();
            }
            return View(sTORY);
        }

        // GET: STORies/Create
        public ActionResult Create()
        {
            ViewBag.nguoi_dang = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap");
            return View();
        }

        // POST: STORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_truyen,ten_truyen,tac_gia,the_loai,mo_ta,ngay_dang,nguoi_dang")] STORY sTORY)
        {
            if (ModelState.IsValid)
            {
                db.STORies.Add(sTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nguoi_dang = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", sTORY.nguoi_dang);
            return View(sTORY);
        }

        // GET: STORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STORY sTORY = db.STORies.Find(id);
            if (sTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.nguoi_dang = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", sTORY.nguoi_dang);
            return View(sTORY);
        }

        // POST: STORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_truyen,ten_truyen,tac_gia,the_loai,mo_ta,ngay_dang,nguoi_dang")] STORY sTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nguoi_dang = new SelectList(db.NGUOI_DUNG, "ma_nguoi_dung", "ten_dang_nhap", sTORY.nguoi_dang);
            return View(sTORY);
        }

        // GET: STORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STORY sTORY = db.STORies.Find(id);
            if (sTORY == null)
            {
                return HttpNotFound();
            }
            return View(sTORY);
        }

        // POST: STORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STORY sTORY = db.STORies.Find(id);
            db.STORies.Remove(sTORY);
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
