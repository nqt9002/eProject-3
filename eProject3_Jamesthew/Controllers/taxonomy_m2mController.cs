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
    public class taxonomy_m2mController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: taxonomy_m2m
        public ActionResult Index()
        {
            var taxonomy_m2m = db.taxonomy_m2m.Include(t => t.article).Include(t => t.taxonomy).Include(t => t.user);
            return View(taxonomy_m2m.ToList());
        }

        // GET: taxonomy_m2m/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy_m2m taxonomy_m2m = db.taxonomy_m2m.Find(id);
            if (taxonomy_m2m == null)
            {
                return HttpNotFound();
            }
            return View(taxonomy_m2m);
        }

        // GET: taxonomy_m2m/Create
        public ActionResult Create()
        {
            ViewBag.article_id = new SelectList(db.articles, "id", "title");
            ViewBag.taxonomy_id = new SelectList(db.taxonomies, "id", "title");
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: taxonomy_m2m/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,article_id,taxonomy_id,created_by,created_at")] taxonomy_m2m taxonomy_m2m)
        {
            if (ModelState.IsValid)
            {
                db.taxonomy_m2m.Add(taxonomy_m2m);
                System.Diagnostics.Debug.WriteLine("Article iD: ");
                System.Diagnostics.Debug.WriteLine(taxonomy_m2m.article_id);
                System.Diagnostics.Debug.WriteLine("TAX iD: ");
                System.Diagnostics.Debug.WriteLine(taxonomy_m2m.taxonomy_id);
                System.Diagnostics.Debug.WriteLine("Create At: ");
                System.Diagnostics.Debug.WriteLine(taxonomy_m2m.created_at);
                System.Diagnostics.Debug.WriteLine("Create by: ");
                System.Diagnostics.Debug.WriteLine(taxonomy_m2m.created_by);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.article_id = new SelectList(db.articles, "id", "title", taxonomy_m2m.article_id);
            ViewBag.taxonomy_id = new SelectList(db.taxonomies, "id", "title", taxonomy_m2m.taxonomy_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy_m2m.created_by);
            return View(taxonomy_m2m);
        }

        // GET: taxonomy_m2m/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy_m2m taxonomy_m2m = db.taxonomy_m2m.Find(id);
            if (taxonomy_m2m == null)
            {
                return HttpNotFound();
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "title", taxonomy_m2m.article_id);
            ViewBag.taxonomy_id = new SelectList(db.taxonomies, "id", "title", taxonomy_m2m.taxonomy_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy_m2m.created_by);
            return View(taxonomy_m2m);
        }

        // POST: taxonomy_m2m/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,article_id,taxonomy_id,created_by,created_at")] taxonomy_m2m taxonomy_m2m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxonomy_m2m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "title", taxonomy_m2m.article_id);
            ViewBag.taxonomy_id = new SelectList(db.taxonomies, "id", "title", taxonomy_m2m.taxonomy_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy_m2m.created_by);
            return View(taxonomy_m2m);
        }

        // GET: taxonomy_m2m/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy_m2m taxonomy_m2m = db.taxonomy_m2m.Find(id);
            if (taxonomy_m2m == null)
            {
                return HttpNotFound();
            }
            return View(taxonomy_m2m);
        }

        // POST: taxonomy_m2m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taxonomy_m2m taxonomy_m2m = db.taxonomy_m2m.Find(id);
            db.taxonomy_m2m.Remove(taxonomy_m2m);
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
