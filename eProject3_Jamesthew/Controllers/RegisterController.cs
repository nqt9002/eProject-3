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
    public class RegisterController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,_password,email,package_expirydate,is_admin,is_active,created_at")] user user)
        {
            if (ModelState.IsValid)
            {
                user.is_active = true;
                user.is_admin = false;
                user.created_at = DateTime.Now;
                user.package_expirydate = DateTime.Now;
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Login");
            }
            ViewBag._package = new SelectList(db.packages, "id", "title");
            return View(user);
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
