namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SicknessType")]
    public partial class SicknessType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SicknessType()
        {
            PersonSicknessType = new HashSet<PersonSicknessType>();
            SicknessType1 = new HashSet<SicknessType>();
        }

        public int SicknessTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string SicknessTypeName { get; set; }

        [StringLength(50)]
        public string SicknessTypeSummaryName { get; set; }

        [StringLength(100)]
        public string SicknessTypeZiped { get; set; }

        public int? ParentId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSicknessType> PersonSicknessType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SicknessType> SicknessType1 { get; set; }

        public virtual SicknessType SicknessType2 { get; set; }
    }
}
