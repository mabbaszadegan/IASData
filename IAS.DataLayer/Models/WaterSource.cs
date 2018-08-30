namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WaterSource")]
    public partial class WaterSource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaterSource()
        {
            DepartmentWaterSource = new HashSet<DepartmentWaterSource>();
            SegmentReconnaissanceWaterSource = new HashSet<SegmentReconnaissanceWaterSource>();
            SegmentWaterSource = new HashSet<SegmentWaterSource>();
        }

        public int WaterSourceId { get; set; }

        [Required]
        [StringLength(50)]
        public string WaterSourceName { get; set; }

        [StringLength(2000)]
        public string WaterSourceDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string WaterSourceZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentWaterSource> DepartmentWaterSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceWaterSource> SegmentReconnaissanceWaterSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentWaterSource> SegmentWaterSource { get; set; }
    }
}
