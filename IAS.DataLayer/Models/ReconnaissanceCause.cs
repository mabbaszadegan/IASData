namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReconnaissanceCause")]
    public partial class ReconnaissanceCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReconnaissanceCause()
        {
            FamilyReconnaissance = new HashSet<FamilyReconnaissance>();
            SegmentReconnaissance = new HashSet<SegmentReconnaissance>();
        }

        public int ReconnaissanceCauseId { get; set; }

        [Required]
        [StringLength(100)]
        public string ReconnaissanceCauseName { get; set; }

        [StringLength(2000)]
        public string ReconnaissanceCauseDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string ReconnaissanceCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyReconnaissance> FamilyReconnaissance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissance> SegmentReconnaissance { get; set; }
    }
}
