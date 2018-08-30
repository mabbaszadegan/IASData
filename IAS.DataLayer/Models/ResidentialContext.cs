namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResidentialContext")]
    public partial class ResidentialContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResidentialContext()
        {
            SegmentReconnaissanceResidentialContext = new HashSet<SegmentReconnaissanceResidentialContext>();
            SegmentResidentialContext = new HashSet<SegmentResidentialContext>();
        }

        public int ResidentialContextId { get; set; }

        [StringLength(100)]
        public string ResidentialContextName { get; set; }

        [StringLength(2000)]
        public string ResidentialContextDesc { get; set; }

        [StringLength(2000)]
        public string ResidentialContextZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceResidentialContext> SegmentReconnaissanceResidentialContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentResidentialContext> SegmentResidentialContext { get; set; }
    }
}
