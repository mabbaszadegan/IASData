namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClass")]
    public partial class EducationYearClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClass()
        {
            EducationYearClassCourse = new HashSet<EducationYearClassCourse>();
            EducationYearClassMember = new HashSet<EducationYearClassMember>();
        }

        public int EducationYearClassId { get; set; }

        [Required]
        [StringLength(500)]
        public string EducationYearClassName { get; set; }

        [Required]
        [StringLength(50)]
        public string EducationYearClassSummeryName { get; set; }

        [StringLength(4000)]
        public string EducationYearClassDesc { get; set; }

        [StringLength(4000)]
        public string EducationYearClassZiped { get; set; }

        public int EducationYearId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual EducationYear EducationYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourse> EducationYearClassCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMember> EducationYearClassMember { get; set; }
    }
}
