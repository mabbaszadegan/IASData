namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResidenceType")]
    public partial class ResidenceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResidenceType()
        {
            DepartmentResidenceType = new HashSet<DepartmentResidenceType>();
            Family = new HashSet<Family>();
        }

        public int ResidenceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ResidenceTypeName { get; set; }

        [StringLength(50)]
        public string ResidenceTypeSummaryName { get; set; }

        [StringLength(100)]
        public string ResidenceTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentResidenceType> DepartmentResidenceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
    }
}
