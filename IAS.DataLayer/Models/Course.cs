namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseAssessmentModel = new HashSet<CourseAssessmentModel>();
            EducationYearClassCourse = new HashSet<EducationYearClassCourse>();
            PersonnelCourse = new HashSet<PersonnelCourse>();
        }

        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [StringLength(50)]
        public string CourseSummaryName { get; set; }

        [StringLength(100)]
        public string CourseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAssessmentModel> CourseAssessmentModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourse> EducationYearClassCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelCourse> PersonnelCourse { get; set; }
    }
}
