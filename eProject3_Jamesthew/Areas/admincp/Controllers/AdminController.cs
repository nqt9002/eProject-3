using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProject3_Jamesthew.Models;
using eProject3_Jamesthew.Controllers;

namespace eProject3_Jamesthew.Areas.admincp.Controllers
{
    public class AdminController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();
        private RoleController role = new RoleController();
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (role.GetUserAdmin(User.Identity.Name))
            {
                return View();
            }
            return RedirectToAction("Index", "AccessDeny");
        }
    }
}