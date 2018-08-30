namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CrimeType")]
    public partial class CrimeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CrimeType()
        {
            DepartmentCrimeType = new HashSet<DepartmentCrimeType>();
            PersonCrimeType = new HashSet<PersonCrimeType>();
        }

        public int CrimeTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string CrimeTypeName { get; set; }

        [StringLength(50)]
        public string CrimeTypeSummaryName { get; set; }

        [StringLength(100)]
        public string CrimeTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentCrimeType> DepartmentCrimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCrimeType> PersonCrimeType { get; set; }
    }
}
