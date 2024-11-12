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
    public class UserController : Controller
    {
        private K22CNT3_NKL_2210900035_Project2Entities db = new K22CNT3_NKL_2210900035_Project2Entities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.NGUOI_DUNG.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_nguoi_dung,ten_dang_nhap,mat_khau,email,ngay_dang_ky")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOI_DUNG.Add(nGUOI_DUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nGUOI_DUNG);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_nguoi_dung,ten_dang_nhap,mat_khau,email,ngay_dang_ky")] NGUOI_DUNG nGUOI_DUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOI_DUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUOI_DUNG);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            if (nGUOI_DUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOI_DUNG);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOI_DUNG nGUOI_DUNG = db.NGUOI_DUNG.Find(id);
            db.NGUOI_DUNG.Remove(nGUOI_DUNG);
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
