using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eProject3_Jamesthew.Models;


namespace eProject3_Jamesthew.Controllers
{
    public class RoleController : Controller
    {
        private Jamesthew_Model db = new Jamesthew_Model();
        // GET: Role
        
        public bool GetUserAdmin(string username)
        {
            var user = db.users.FirstOrDefault(u => u.username == username);
            if (user == null)
            {
                return false;
            }
            else
            {
                bool is_Admin = user.is_admin;
                return is_Admin;
            }
        }

        public bool GetUserActive(string username)
        {
            var user = db.users.FirstOrDefault(u => u.username == username);
            if (user == null)
            {
                return false;
            }
            else
            {
                bool is_Active = user.is_active;
                return is_Active;
            }
        }

        public bool GetExDate(string username)
        {
            var user = db.users.FirstOrDefault(u => u.username == username);
            if(user == null)
            {
                return false;
            }
            else
            {
                if (GetUserAdmin(username))
                {
                    return true;
                }
                bool ex =  (DateTime.Compare(user.package_expirydate.Value, DateTime.Now) > 0);
                return ex;
            }
        }

    }
}