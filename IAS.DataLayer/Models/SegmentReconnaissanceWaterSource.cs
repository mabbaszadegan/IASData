namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentReconnaissanceWaterSource")]
    public partial class SegmentReconnaissanceWaterSource
    {
        public int SegmentReconnaissanceWaterSourceId { get; set; }

        public int SegmentReconnaissanceId { get; set; }

        public int WaterSourceId { get; set; }

        public double WaterSourcePercent { get; set; }

        [StringLength(3000)]
        public string WaterSourceDesc { get; set; }

        [StringLength(3000)]
        public string WaterSourceZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual WaterSource WaterSource { get; set; }
    }
}
