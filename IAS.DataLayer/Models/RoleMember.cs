namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMember")]
    public partial class RoleMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleMember()
        {
            RoleMemberAccess = new HashSet<RoleMemberAccess>();
        }

        public int RoleMemberId { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        public int? UserDepartmentId { get; set; }

        public bool RoleMemberIsDefault { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual UserDepartment UserDepartment { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMemberAccess> RoleMemberAccess { get; set; }
    }
}
