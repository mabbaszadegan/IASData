namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClassCourse")]
    public partial class EducationYearClassCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClassCourse()
        {
            EducationYearClassCourseTime = new HashSet<EducationYearClassCourseTime>();
        }

        public int EducationYearClassCourseId { get; set; }

        public int EducationYearClassId { get; set; }

        public int CourseId { get; set; }

        public int PersonnelId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Course Course { get; set; }

        public virtual EducationYearClass EducationYearClass { get; set; }

        public virtual Personnel Personnel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourseTime> EducationYearClassCourseTime { get; set; }
    }
}
