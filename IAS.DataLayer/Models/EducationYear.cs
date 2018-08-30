namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYear")]
    public partial class EducationYear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYear()
        {
            EducationYearClass = new HashSet<EducationYearClass>();
        }

        public int EducationYearId { get; set; }

        [Required]
        [StringLength(50)]
        public string EducationYearName { get; set; }

        [StringLength(50)]
        public string EducationYearSummaryName { get; set; }

        [StringLength(100)]
        public string EducationYearZiped { get; set; }

        public bool EducationYearIsDefault { get; set; }

        public int DepartmentId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClass> EducationYearClass { get; set; }
    }
}
