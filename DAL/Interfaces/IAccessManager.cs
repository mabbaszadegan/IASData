using IASData.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAccessManager
    {

        AccessItem AllowLogin(string userName, string password, bool? isActive = true);
        List<AccessItem> GetAccessList(int userId, int? departmentId = null);
        List<AccessItem> GetAccessList(Guid userId, int? departmentId = null);
        List<AccessItem> GetAccessList(int userId, int? departmentId, Controllers controller);
        List<AccessItem> GetAccessList(Guid userId, int? departmentId, Controllers controller);
        List<AccessItem> GetAccessList(int userId, int? departmentId, Controllers controller, FeatureTypes featureType);
        List<AccessItem> GetAccessList(Guid userId, int? departmentId, Controllers controller, FeatureTypes featureType);


    }
}
