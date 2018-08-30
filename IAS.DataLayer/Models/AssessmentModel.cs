namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssessmentModel")]
    public partial class AssessmentModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentModel()
        {
            AssessmentModelValue = new HashSet<AssessmentModelValue>();
            CourseAssessmentModel = new HashSet<CourseAssessmentModel>();
            EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
        }

        public int AssessmentModelId { get; set; }

        [Required]
        [StringLength(50)]
        public string AssessmentModelName { get; set; }

        [StringLength(50)]
        public string AssessmentModelSummaryName { get; set; }

        [StringLength(100)]
        public string AssessmentModelZiped { get; set; }

        public bool AssessmentModelHasVariableValue { get; set; }

        public int AssessmentModelCategoryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual AssessmentModelCategory AssessmentModelCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentModelValue> AssessmentModelValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseAssessmentModel> CourseAssessmentModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
    }
}
