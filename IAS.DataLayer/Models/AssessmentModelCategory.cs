namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssessmentModelCategory")]
    public partial class AssessmentModelCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentModelCategory()
        {
            AssessmentModel = new HashSet<AssessmentModel>();
        }

        public int AssessmentModelCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string AssessmentModelCategoryName { get; set; }

        [StringLength(50)]
        public string AssessmentModelCategorySummaryName { get; set; }

        [StringLength(100)]
        public string AssessmentModelCategoryZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentModel> AssessmentModel { get; set; }
    }
}
