namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChildAbuseType")]
    public partial class ChildAbuseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChildAbuseType()
        {
            DepartmentChildAbuseType = new HashSet<DepartmentChildAbuseType>();
            PersonChildAbuseType = new HashSet<PersonChildAbuseType>();
        }

        public int ChildAbuseTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildAbuseTypeName { get; set; }

        [StringLength(50)]
        public string ChildAbuseTypeSummaryName { get; set; }

        [StringLength(100)]
        public string ChildAbuseTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentChildAbuseType> DepartmentChildAbuseType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonChildAbuseType> PersonChildAbuseType { get; set; }
    }
}
