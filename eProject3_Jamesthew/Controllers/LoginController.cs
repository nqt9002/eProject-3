using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eProject3_Jamesthew.Models;
using eProject3_Jamesthew.Controllers;

namespace eProject3_Jamesthew.Areas.admincp.Controllers
{
    public class LoginController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user userLog)
        {
            if (userLog != null)
            {
                var user_validate = db.users.Where(u => u.username == userLog.username && u._password == userLog._password).FirstOrDefault();
                if (user_validate != null)
                {
                    FormsAuthentication.SetAuthCookie(userLog.username, false);
                    return RedirectToDefault(userLog);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User. Please try again!!!");
                }
                
            }
            return View(userLog);
        }

        public ActionResult RedirectToDefault(user user)
        {
            RoleController role = new RoleController();
            bool is_Admin = role.GetUserAdmin(user.username);
            bool is_Active = role.GetUserActive(user.username);
            bool get_ExDate = role.GetExDate(user.username);
            if (is_Admin == true && is_Active == true)
            {
                return RedirectToAction("Index", "admincp");
            }
            else if (is_Admin == false && is_Active == true && get_ExDate == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else if(is_Admin == false && is_Active == true && get_ExDate == false)
            {
                return RedirectToAction("Create", "VIP");
            }
            else
            {
                return RedirectToAction("Index", "Deactive");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
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
