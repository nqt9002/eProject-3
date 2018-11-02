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
    public class TaxonomyController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Taxonomy
        public ActionResult Index(string type)
        {
            var _index_data_type = type;
            var taxonomies = db.taxonomies.Include(t => t.user);
            return View(taxonomies.ToList().Where(c => c.content_type == type));
        }

        // GET: Taxonomy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy taxonomy = db.taxonomies.Find(id);
            if (taxonomy == null)
            {
                return HttpNotFound();
            }
            return View(taxonomy);
        }

        // GET: Taxonomy/Create
        public ActionResult Create()
        {
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: Taxonomy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body,excerpt,content_type,created_by,created_at")] taxonomy taxonomy)
        {
            if (ModelState.IsValid)
            {
                db.taxonomies.Add(taxonomy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy.created_by);
            return View(taxonomy);
        }

        // GET: Taxonomy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy taxonomy = db.taxonomies.Find(id);
            if (taxonomy == null)
            {
                return HttpNotFound();
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy.created_by);
            return View(taxonomy);
        }

        // POST: Taxonomy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,excerpt,content_type,created_by,created_at")] taxonomy taxonomy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxonomy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy.created_by);
            return View(taxonomy);
        }

        // GET: Taxonomy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taxonomy taxonomy = db.taxonomies.Find(id);
            if (taxonomy == null)
            {
                return HttpNotFound();
            }
            return View(taxonomy);
        }

        // POST: Taxonomy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taxonomy taxonomy = db.taxonomies.Find(id);
            db.taxonomies.Remove(taxonomy);
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
