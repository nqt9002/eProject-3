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
    public class FeedbacksController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: feedbacks
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var feedbacks = db.feedbacks.Include(f => f.article).Include(f => f.user);
            return View(feedbacks.ToList());
        }

        // GET: feedbacks/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: feedbacks/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.article_id = new SelectList(db.articles, "id", "title");
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,article_id,body,created_by,created_at")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.created_at = DateTime.Now;
                feedback.created_by =  db.users.Where(u => u.username == User.Identity.Name).FirstOrDefault().id;
                db.feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.article_id = new SelectList(db.articles, "id", "title", feedback.article_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", feedback.created_by);
            return View(feedback);
        }

        // GET: feedbacks/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "title", feedback.article_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", feedback.created_by);
            return View(feedback);
        }

        // POST: feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,article_id,body,created_by,created_at")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.article_id = new SelectList(db.articles, "id", "title", feedback.article_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", feedback.created_by);
            return View(feedback);
        }

        // GET: feedbacks/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback feedback = db.feedbacks.Find(id);
            db.feedbacks.Remove(feedback);
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
