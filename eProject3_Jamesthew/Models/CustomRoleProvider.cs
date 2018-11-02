using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using eProject3_Jamesthew.Controllers;

namespace eProject3_Jamesthew.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        Jamesthew_Model db = new Jamesthew_Model();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = db.users.FirstOrDefault(u => u.username == username);
            RoleController _role = new RoleController();
            var is_Admin = _role.GetUserAdmin(username);
            var is_Active = _role.GetUserActive(username);
            if(user != null && is_Admin == true)
            {
                return new String[] { "Admin" };
            }
            else if(user != null && is_Admin == false && is_Active == true)

            {
                return new string[] { "User" };
            }
            else
            {
                return new string[] {};
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}