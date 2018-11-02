using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3_Jamesthew.Models;

namespace eProject3_Jamesthew.Areas.customer.Controllers
{
    public class ProfileController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: customer/Profile/Details/5
        [Authorize(Roles = "User,Admin")]
        public ActionResult Details(string type)
        {
            if (type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Where(u => u.username == type).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: customer/Profile/Edit/5
        [Authorize(Roles = "User,Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: customer/Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,_password,email,package_expirydate,is_admin,is_active,created_at")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PostList", new { type = User.Identity.Name });
            }
            return View(user);
        }

        //area for user post recipe and tip
        [Authorize(Roles = "User,Admin")]
        public ActionResult PostList(string type)
        {
            var find_ID = db.users.Where(u => u.username == type).FirstOrDefault();
            var articles = db.articles.Include(a => a.user);
            return View(articles.ToList().Where(u => u.created_by == find_ID.id));
        }

        //upload images
        string ImagePath;
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase ImageFile)
        {
            string filename = Path.GetFileName(ImageFile.FileName);
            string path = Path.Combine(Server.MapPath(@"~/Images/"), filename);
            ImagePath = @"~/images/" + filename;
            if (System.IO.File.Exists(path))
            {
                ViewBag.Message = "Image is available. Please choose another image.";
            }
            else
            {
                ImageFile.SaveAs(path);
                ViewBag.Message = "Upload Success!";
            }
            return View();
        }

        // GET: Post/Create
        [Authorize(Roles = "User,Admin")]
        public ActionResult PostProduct(string content_type)
        {
            var tax_Content_Type = from t in db.taxonomies select t;
            ViewBag._content_type = content_type;
            ViewBag.created_by = new SelectList(db.users, "id", "username");
            ViewBag._taxonomies = new SelectList(tax_Content_Type.Where(c => c.content_type.Equals("Material")), "id", "title");
            ViewBag._taxonomies_category = new SelectList(tax_Content_Type.Where(c => c.content_type.Equals("Category")), "id", "title");
            return View();
        }

        // POST: POst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult PostProduct(article article, string[] _taxonomies, string[] _taxonomies_category, string[] _article_meta, string _premium, HttpPostedFileBase ImageFile, string content_type)
        {
            ViewBag._content_type = content_type;
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    Upload(ImageFile);
                    article.setMeta("imagefile", ImagePath);
                }

                if (_premium != null)
                {
                    article.setMeta("premium", _premium);
                }

                //save to article
                article.published_at = DateTime.Now;
                article.created_at = DateTime.Now;
                db.articles.Add(article);
                db.SaveChanges();

                if (_taxonomies != null)
                {
                    taxonomiesToData(_taxonomies, article);
                }

                if (_taxonomies_category != null)
                {
                    taxonomiesToData(_taxonomies_category, article);
                }

                return RedirectToAction("PostList", new { type = User.Identity.Name });
            }
            var tax_Content_Type = from t in db.taxonomies select t;
            ViewBag.created_by = new SelectList(db.users, "id", "username", article.created_by);
            ViewBag._taxonomies = new SelectList(tax_Content_Type.Where(c => c.content_type == "Material"), "id", "title");
            ViewBag._taxonomies_category = new SelectList(tax_Content_Type.Where(c => c.content_type == "Category"), "C_key", "C_value");

            return View(article);
        }

        public void taxonomiesToData(string[] data, article article)
        {
            foreach (var taxo_id in data)
            {
                taxonomy_m2m new_m2m = new taxonomy_m2m();
                new_m2m.article_id = article.id;
                new_m2m.taxonomy_id = int.Parse(taxo_id);
                new_m2m.created_at = DateTime.Now;
                new_m2m.created_by = article.created_by;
                db.taxonomy_m2m.Add(new_m2m);
            }
            db.SaveChanges();
        }

        [Authorize(Roles = "User,Admin")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            article article = db.articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", article.created_by);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "id,title,body,excerpt,content_type,published_at,created_by,created_at")] article article, string content_type)
        {
            ViewBag._content_type = content_type;
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PostList", new { type = User.Identity.Name });
            }
            ViewBag.created_by = new SelectList(db.users, "id", "username", article.created_by);
            return View(article);
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
