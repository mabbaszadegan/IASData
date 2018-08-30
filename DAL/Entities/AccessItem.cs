using IASData.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccessItem
    {
        public bool IsAccessible { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public Guid? UserTempId { get; set; }
        public int? RoleId { get; set; }
        public Controllers ControllerName { get; set; }
        public FeatureTypes FeatureTypeName { get; set; }
        public int SubsystemId { get; set; }
        public int? ParentSubsystemId { get; set; }
        public string SubsystemName { get; set; }
        public int DepartmentId { get; set; }
    }
}
