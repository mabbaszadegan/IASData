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
    
    public partial class EducationYearClassCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClassCourse()
        {
            this.EducationYearClassCourseTime = new HashSet<EducationYearClassCourseTime>();
        }
    
        public int EducationYearClassCourseId { get; set; }
        public int EducationYearClassId { get; set; }
        public int CourseId { get; set; }
        public int PersonnelId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual EducationYearClass EducationYearClass { get; set; }
        public virtual Personnel Personnel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourseTime> EducationYearClassCourseTime { get; set; }
    }
}
