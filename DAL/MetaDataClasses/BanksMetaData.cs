using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class BanksMetaData
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserZiped { get; set; }
        public bool UserIsActive { get; set; }
        public bool UserIsAdmin { get; set; }
        public bool UserIsMedicine { get; set; }
        public bool UserIsEducation { get; set; }
        public bool UserIsAid { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<System.Guid> TempId { get; set; }
        public Nullable<int> PersonnelId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }

        [MetadataType(typeof(BanksMetaData))]
        public partial class Bank
        {

        }

}
}
