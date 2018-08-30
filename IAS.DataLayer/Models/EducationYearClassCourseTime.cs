namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClassCourseTime")]
    public partial class EducationYearClassCourseTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClassCourseTime()
        {
            EducationYearClassCourseHistory = new HashSet<EducationYearClassCourseHistory>();
            EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
        }

        public int EducationYearClassCourseTimeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EducationYearClassCourseTimeName { get; set; }

        [StringLength(50)]
        public string EducationYearClassCourseTimeSummaryName { get; set; }

        [Required]
        [StringLength(5)]
        public string EducationYearClassCourseTimeFrom { get; set; }

        [Required]
        [StringLength(5)]
        public string EducationYearClassCourseTimeTo { get; set; }

        [StringLength(4000)]
        public string EducationYearClassCourseTimeZiped { get; set; }

        public int EducationYearClassCourseId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual EducationYearClassCourse EducationYearClassCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourseHistory> EducationYearClassCourseHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
    }
}
