namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssessmentModelValue")]
    public partial class AssessmentModelValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentModelValue()
        {
            EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
        }

        public int AssessmentModelValueId { get; set; }

        [Required]
        [StringLength(50)]
        public string AssessmentModelValueName { get; set; }

        [StringLength(50)]
        public string AssessmentModelValueEnglishName { get; set; }

        [StringLength(100)]
        public string AssessmentModelValueZiped { get; set; }

        public bool AssessmentModelValueIsDefault { get; set; }

        public int AssessmentModelId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual AssessmentModel AssessmentModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
    }
}
