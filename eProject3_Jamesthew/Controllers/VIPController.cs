using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3_Jamesthew.Models;

namespace eProject3_Jamesthew.Controllers
{
    public class VIPController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: VIP

        // GET: VIP/Details/5
        [Authorize(Roles = "User")]
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

        // GET: VIP/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            ViewBag.package_id = new SelectList(db.packages, "id", "title");
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: VIP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,package_id,title,card_number,card_expirydate,csc,created_by,created_at")] payment payment, package _pack)
        { 
            if (payment != null)
            { 
                payment.created_at = DateTime.Now;
                payment.created_by = db.users.Where(c => c.username == User.Identity.Name).FirstOrDefault().id;
                System.Diagnostics.Debug.WriteLine(db.users.Where(c => c.username == User.Identity.Name).FirstOrDefault().id);
                db.payments.Add(payment);
                db.SaveChanges();
                var update = db.users.SingleOrDefault(u => u.username == User.Identity.Name);
                update.package_expirydate = DateTime.Now.AddDays(db.packages.Find(payment.package_id).expirydate);
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.package_id = new SelectList(db.packages, "id", "title", payment.package_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", payment.created_by);
            return View(payment);
        }

        // GET: VIP/Edit/5
        [Authorize(Roles = "User")]
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

        // POST: VIP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
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
