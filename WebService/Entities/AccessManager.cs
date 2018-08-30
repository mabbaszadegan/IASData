using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using IASData.Enumerable;

namespace WebService
{
    public class AccessManager : IAccessManager
    {
        private readonly UnitOfWork _db;

        public AccessManager(UnitOfWork dbset)
        {
            _db = dbset;
        }

        public AccessManager()
        {

        }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public Guid? UserTempId { get; set; }
        public int? RoleId { get; set; }
        public IASData.Enumerable.Controllers ControllerName { get; set; }
        public FeatureTypes FeatureTypeName { get; set; }
        public string SubsystemName { get; set; }
        public int DepartmentId { get; set; }

        public AccessItem AllowLogin(string userName, string password, bool? isActive = true)
        {
            AccessItem result = new AccessItem();
            Guid tempId = Guid.NewGuid();
            var user = !isActive.HasValue
                ? _db.UserInfoRepository.Get(q => q.UserName == userName && q.UserPassword == password).FirstOrDefault()
                : _db.UserInfoRepository.Get(q => q.UserName == userName && q.UserPassword == password && q.UserIsActive == isActive).FirstOrDefault();

            if (user != null)
            {
                user.TempId = tempId;

                _db.UserInfoRepository.Update(user);
                _db.Save();

                result.IsAccessible = true;
                result.IsActive = true;
                result.UserName = user.UserName;
                result.UserFirstName = user.UserFirstName;
                result.UserLastName = user.UserLastName;
                result.UserTempId = user.TempId;

            }
            else
            {
                result.IsAccessible = false;
                result.IsActive = false;
            }
            return result;
        }

        public List<AccessItem> GetAccessList(int userId, int? departmentId = null)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserId == userId).ToList()[0].DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q => roles.Contains(q.RoleId));
            foreach (var item in accessList)
            {
                Enum.TryParse(item.Feature.FeatureType.FeatureTypeName, out FeatureTypes tempFeatureTypeName);

                Enum.TryParse(item.Feature.SubSystem.ControlName, out IASData.Enumerable.Controllers tempControllerName);
                var temp = new AccessItem
                {
                    SubsystemName = item.Feature.SubSystem.SubSystemName,
                    ControllerName = tempControllerName,
                    FeatureTypeName = tempFeatureTypeName
                };

                result.Add(temp);
            }

            return result;
        }

        public List<AccessItem> GetAccessList(Guid userId, int? departmentId = null)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserInfo.TempId == userId).FirstOrDefault()?.DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserInfo.TempId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q => roles.Contains(q.RoleId));
            foreach (var item in accessList)
            {
                Enum.TryParse(item.Feature.FeatureType.FeatureTypeNameEnglish, out FeatureTypes tempFeatureTypeName);

                Enum.TryParse(item.Feature.SubSystem.ControlName, out IASData.Enumerable.Controllers tempControllerName);
                var temp = new AccessItem
                {
                    SubsystemId = item.Feature.SubSystemId,
                    ParentSubsystemId = item.Feature.SubSystem.ParentId,
                    SubsystemName = item.Feature.SubSystem.SubSystemName,
                    ControllerName = tempControllerName,
                    FeatureTypeName = tempFeatureTypeName,
                    DepartmentId = departmentId.Value
                };

                result.Add(temp);
            }

            return result;

        }

        public List<AccessItem> GetAccessList(int userId, int? departmentId, IASData.Enumerable.Controllers controller)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserId == userId).ToList()[0].DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q => roles.Contains(q.RoleId) && q.Feature.SubSystem.ControlName == controller.ToString());
            foreach (var item in accessList)
            {
                Enum.TryParse(item.Feature.FeatureType.FeatureTypeName, out FeatureTypes tempFeatureTypeName);
                var temp = new AccessItem { FeatureTypeName = tempFeatureTypeName };

                result.Add(temp);
            }

            return result;

        }

        public List<AccessItem> GetAccessList(Guid userId, int? departmentId, IASData.Enumerable.Controllers controller)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserInfo.TempId == userId).ToList()[0].DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserInfo.TempId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q => roles.Contains(q.RoleId) && q.Feature.SubSystem.ControlName == controller.ToString());
            foreach (var item in accessList)
            {
                Enum.TryParse(item.Feature.FeatureType.FeatureTypeName, out FeatureTypes tempFeatureTypeName);
                var temp = new AccessItem { FeatureTypeName = tempFeatureTypeName };


                result.Add(temp);
            }

            return result;

        }

        public List<AccessItem> GetAccessList(int userId, int? departmentId, IASData.Enumerable.Controllers controller, FeatureTypes featureType)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserId == userId).ToList()[0].DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q =>
                            roles.Contains(q.RoleId) &&
                            q.Feature.SubSystem.ControlName == controller.ToString() &&
                            q.Feature.FeatureType.FeatureTypeName == featureType.ToString()
                );
            foreach (var item in accessList)
            {
                var temp = new AccessItem { IsActive = true };
                result.Add(temp);
            }

            return result;
        }

        public List<AccessItem> GetAccessList(Guid userId, int? departmentId, IASData.Enumerable.Controllers controller, FeatureTypes featureType)
        {
            List<AccessItem> result = new List<AccessItem>();
            List<int> roles = new List<int>();
            if (!departmentId.HasValue)
                departmentId = _db.UserDepartmentRepository.Get(q => q.UserInfo.TempId == userId).ToList()[0].DepartmentId;

            foreach (var item in _db.RoleMemberRepository.Get(q => q.UserDepartment.DepartmentId == departmentId && q.UserDepartment.UserInfo.TempId == userId))
            {
                roles.Add(item.RoleId);
            }

            var accessList = _db.AccessLevelRepository.Get(q =>
                roles.Contains(q.RoleId) &&
                q.Feature.SubSystem.ControlName == controller.ToString() &&
                q.Feature.FeatureType.FeatureTypeName == featureType.ToString()
            );
            foreach (var item in accessList)
            {
                var temp = new AccessItem();
                Enum.TryParse(item.Feature.FeatureType.FeatureTypeName, out FeatureTypes tempFeatureTypeName);

                Enum.TryParse(item.Feature.SubSystem.ControlName, out IASData.Enumerable.Controllers tempControllerName);

                temp.ControllerName = tempControllerName;
                temp.FeatureTypeName = tempFeatureTypeName;
                result.Add(temp);
            }

            return result;
        }
    }
}