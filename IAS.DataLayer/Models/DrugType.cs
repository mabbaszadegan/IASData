namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrugType")]
    public partial class DrugType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugType()
        {
            DepartmentDrugType = new HashSet<DepartmentDrugType>();
            PersonDrugType = new HashSet<PersonDrugType>();
            SegmentDrugType = new HashSet<SegmentDrugType>();
            SegmentReconnaissanceDrugType = new HashSet<SegmentReconnaissanceDrugType>();
        }

        public int DrugTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugTypeName { get; set; }

        [StringLength(50)]
        public string DrugTypeSummaryName { get; set; }

        [StringLength(100)]
        public string DrugTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentDrugType> DepartmentDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDrugType> PersonDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentDrugType> SegmentDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceDrugType> SegmentReconnaissanceDrugType { get; set; }
    }
}
