namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TreatmentStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TreatmentStatus()
        {
            PersonSicknessType = new HashSet<PersonSicknessType>();
        }

        public int TreatmentStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string TreatmentStatusName { get; set; }

        [StringLength(50)]
        public string TreatmentStatusSummaryName { get; set; }

        [StringLength(100)]
        public string TreatmentStatusZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSicknessType> PersonSicknessType { get; set; }
    }
}
