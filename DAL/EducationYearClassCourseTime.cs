//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EducationYearClassCourseTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClassCourseTime()
        {
            this.EducationYearClassCourseHistory = new HashSet<EducationYearClassCourseHistory>();
            this.EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
        }
    
        public int EducationYearClassCourseTimeId { get; set; }
        public string EducationYearClassCourseTimeName { get; set; }
        public string EducationYearClassCourseTimeSummaryName { get; set; }
        public string EducationYearClassCourseTimeFrom { get; set; }
        public string EducationYearClassCourseTimeTo { get; set; }
        public string EducationYearClassCourseTimeZiped { get; set; }
        public int EducationYearClassCourseId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual EducationYearClassCourse EducationYearClassCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourseHistory> EducationYearClassCourseHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
    }
}
