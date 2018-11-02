using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3_Jamesthew.Models;

namespace eProject3_Jamesthew.Areas.admincp.Controllers
{
    public class PaymentsController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Payments
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var payments = db.payments.Include(p => p.package).Include(p => p.user);
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.package_id = new SelectList(db.packages, "id", "title");
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,package_id,title,card_number,card_expirydate,csc,created_by,created_at")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.package_id = new SelectList(db.packages, "id", "title", payment.package_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", payment.created_by);
            return View(payment);
        }

        // GET: Payments/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.package_id = new SelectList(db.packages, "id", "title", payment.package_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", payment.created_by);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,package_id,title,card_number,card_expirydate,csc,created_by,created_at")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.package_id = new SelectList(db.packages, "id", "title", payment.package_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", payment.created_by);
            return View(payment);
        }

        // GET: Payments/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = db.payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            payment payment = db.payments.Find(id);
            db.payments.Remove(payment);
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
