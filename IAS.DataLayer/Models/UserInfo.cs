namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            RoleMember = new HashSet<RoleMember>();
            UserDepartment = new HashSet<UserDepartment>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserFirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(1000)]
        public string UserZiped { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsAdmin { get; set; }

        public bool UserIsMedicine { get; set; }

        public bool UserIsEducation { get; set; }

        public bool UserIsAid { get; set; }

        public int? DepartmentId { get; set; }

        public int? PersonnelId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Personnel Personnel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMember> RoleMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDepartment> UserDepartment { get; set; }
    }
}
