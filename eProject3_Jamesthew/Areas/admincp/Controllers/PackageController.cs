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
    public class PackageController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Package
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var packages = db.packages.Include(p => p.user);
            return View(packages.ToList());
        }

        // GET: Package/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            package package = db.packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Package/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: Package/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body,price,expirydate,is_public,created_by,created_at")] package package)
        {
            if (ModelState.IsValid)
            {
                package.created_at = DateTime.Now;
                package.created_by = db.users.Where(u => u.username == User.Identity.Name).FirstOrDefault().id;
                db.packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.created_by = new SelectList(db.users, "id", "username", package.created_by);
            return View(package);
        }

        // GET: Package/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            package package = db.packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", package.created_by);
            return View(package);
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,price,expirydate,is_public,created_by,created_at")] package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", package.created_by);
            return View(package);
        }

        // GET: Package/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            package package = db.packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            package package = db.packages.Find(id);
            db.packages.Remove(package);
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
