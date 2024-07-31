using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MyCodeFirst.Models;

namespace FIT5032_MyCodeFirst.Controllers
{
    public class unitsController : Controller
    {
        private FIT5032_Models db = new FIT5032_Models();

        // GET: units
        public ActionResult Index()
        {
            var units = db.units.Include(u => u.students);
            return View(units.ToList());
        }

        // GET: units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            units units = db.units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            return View(units);
        }

        // GET: units/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "id", "name");
            return View();
        }

        // POST: units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,student_id")] units units)
        {
            if (ModelState.IsValid)
            {
                db.units.Add(units);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "id", "name", units.student_id);
            return View(units);
        }

        // GET: units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            units units = db.units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "id", "name", units.student_id);
            return View(units);
        }

        // POST: units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,student_id")] units units)
        {
            if (ModelState.IsValid)
            {
                db.Entry(units).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "id", "name", units.student_id);
            return View(units);
        }

        // GET: units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            units units = db.units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            return View(units);
        }

        // POST: units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            units units = db.units.Find(id);
            db.units.Remove(units);
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
