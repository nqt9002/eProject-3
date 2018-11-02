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
    public class ContentController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Content
        public ActionResult Index(string type)
        {
            ViewBag._index_data_type = type;
            var articles = db.articles.Include(a => a.user);
            return View(articles.ToList().Where(c => c.content_type == type));
        }

        public ActionResult Filter(int type)
        {
            ViewBag._index_data_type = type;
            var articles = db.articles.Include(a => a.user);
            return View(articles.ToList().Where(c => c.taxonomy_m2m.Any(t => t.taxonomy_id == type)));
        }

        public ActionResult Contest(string type)
        {
            ViewBag._index_content_type = type;
            var taxonomies = db.taxonomies.Include(t => t.user);
            return View(taxonomies.ToList().Where(c => c.content_type == type));
        }

        // GET: Content/Details/5
        public ActionResult Details(int? id, string type)
        {
            var tax_Content_Type = from t in db.taxonomies select t;
            ViewBag._index_data_type = type;
            ViewBag._taxonomies = new SelectList(tax_Content_Type.Where(c => c.content_type.Equals("Material")), "id", "title");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            ViewBag._index_feedback = db.feedbacks.Include(f => f.user).Where(f => f.article_id == id).ToList();
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: feedbacks/Create
        [Authorize(Roles = "User")]
        public ActionResult FeedBack()
        {
            ViewBag.article_id = new SelectList(db.articles, "id", "title");
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult FeedBack([Bind(Include = "id,article_id,body,created_by,created_at")] feedback feedback, int type)
        {
            if (ModelState.IsValid)
            {
                feedback.article_id = type;
                feedback.created_at = DateTime.Now;
                feedback.created_by = db.users.Where(u => u.username == User.Identity.Name).FirstOrDefault().id;
                db.feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.article_id = new SelectList(db.articles, "id", "title", feedback.article_id);
            ViewBag.created_by = new SelectList(db.users, "id", "username", feedback.created_by);
            return View(feedback);
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
