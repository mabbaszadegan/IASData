namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClassMemberHistory")]
    public partial class EducationYearClassMemberHistory
    {
        public int EducationYearClassMemberHistoryId { get; set; }

        [Required]
        [StringLength(10)]
        public string EducationYearClassMemberHistoryDateSolar { get; set; }

        public DateTime EducationYearClassMemberHistoryDate { get; set; }

        public int? EducationYearClassCourseTimeId { get; set; }

        public int? AssessorId { get; set; }

        public int? AssessorName { get; set; }

        public int EducationYearClassMemberId { get; set; }

        public int? AssessmentModelId { get; set; }

        public int? CourseAssessmentModelId { get; set; }

        public int? AssessmentModelValueId { get; set; }

        public double? AssessmentModelValue { get; set; }

        [StringLength(4000)]
        public string AssessmentModelDesc { get; set; }

        [StringLength(4000)]
        public string AssessmentModelZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual AssessmentModel AssessmentModel { get; set; }

        public virtual AssessmentModelValue AssessmentModelValue1 { get; set; }

        public virtual CourseAssessmentModel CourseAssessmentModel { get; set; }

        public virtual EducationYearClassCourseTime EducationYearClassCourseTime { get; set; }

        public virtual EducationYearClassMember EducationYearClassMember { get; set; }

        public virtual Personnel Personnel { get; set; }
    }
}
