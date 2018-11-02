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
    public class TaxonomiesController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Taxonomies
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string content_type)
        {
            ViewBag._index_content_type = content_type;
            var taxonomies = db.taxonomies.Include(t => t.user);
            return View(taxonomies.ToList().Where(c => c.content_type == content_type));
        }

        // GET: Taxonomies/Details/5
        [Authorize(Roles = "Admin")]
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

        // GET: Taxonomies/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(string content_type)
        {
            ViewBag._content_type = content_type;
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: Taxonomies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body,excerpt,content_type,created_by,created_at")] taxonomy taxonomy, string content_type)
        {
            if (ModelState.IsValid)
            {
                ViewBag._content_type = content_type;
                taxonomy.created_at = DateTime.Now;
                taxonomy.created_by = db.users.Where(u => u.username == User.Identity.Name).FirstOrDefault().id;
                db.taxonomies.Add(taxonomy);
                db.SaveChanges();
                return RedirectToAction("Index", new { content_type });
            }

            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy.created_by);
            return View(taxonomy);
        }

        // GET: Taxonomies/Edit/5
        [Authorize(Roles = "Admin")]
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

        // POST: Taxonomies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,excerpt,content_type,created_by,created_at")] taxonomy taxonomy, string content_type)
        {
            ViewBag._content_type = content_type;
            if (ModelState.IsValid)
            {
                db.Entry(taxonomy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { content_type });
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", taxonomy.created_by);
            return View(taxonomy);
        }

        // GET: Taxonomies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id, string content_type)
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
            return RedirectToAction("Index", new { content_type });
        }

        // POST: Taxonomies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string content_type)
        {
            ViewBag._content_type = content_type;
            taxonomy taxonomy = db.taxonomies.Find(id);
            db.taxonomies.Remove(taxonomy);
            db.SaveChanges();
            return RedirectToAction("Index", new { content_type });
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
