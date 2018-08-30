namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClassCourseHistory")]
    public partial class EducationYearClassCourseHistory
    {
        public int EducationYearClassCourseHistoryId { get; set; }

        [Required]
        [StringLength(4000)]
        public string EducationYearClassCourseHistoryCourseDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string EducationYearClassCourseHistoryClassTarget { get; set; }

        [Required]
        [StringLength(4000)]
        public string EducationYearClassCourseHistoryClassDesc { get; set; }

        [StringLength(4000)]
        public string EducationYearClassCourseHistoryClassPracticeDesc { get; set; }

        [StringLength(4000)]
        public string EducationYearClassCourseHistoryHomePracticeDesc { get; set; }

        [StringLength(4000)]
        public string EducationYearClassCourseHistoryRecommendation { get; set; }

        [StringLength(4000)]
        public string EducationYearClassCourseHistorySpecialDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string EducationYearClassCourseHistoryZiped { get; set; }

        [Required]
        [StringLength(10)]
        public string EducationYearClassCourseHistoryDateSolar { get; set; }

        public DateTime EducationYearClassCourseHistoryDate { get; set; }

        public int EducationYearClassCourseTimeId { get; set; }

        public int? SuccessorId { get; set; }

        [StringLength(4000)]
        public string SuccessorName { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual EducationYearClassCourseTime EducationYearClassCourseTime { get; set; }

        public virtual Personnel Personnel { get; set; }
    }
}
