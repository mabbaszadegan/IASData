using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DAL;

namespace IASData.Provider
{
    public class IASRoleProvider : RoleProvider
    {
        UnitOfWork db = new UnitOfWork();
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
            var a = db.RoleMemberRepository.Get().Select(r => r.Role.RoleSystemName).ToArray();
            return a;
        }

        public override string[] GetRolesForUser(string username)
        {
            var a = db.RoleMemberRepository.Get(u => u.UserInfo.UserName == username && !string.IsNullOrEmpty(u.Role.RoleSystemName)).Select(r => r.Role.RoleSystemName).ToArray();
            return a;
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