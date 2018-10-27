using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProject3_Jamesthew.Models;

namespace eProject3_Jamesthew.Controllers
{
    public class AdminController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();
        private RoleController role = new RoleController();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            if (role.GetUserAdmin(User.Identity.Name))
            {
                return View(db.users.ToList());
            }
            return RedirectToAction("Index", "AccessDeny");
        }

    }
}