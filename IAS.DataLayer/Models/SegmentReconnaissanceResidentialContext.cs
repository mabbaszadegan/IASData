namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentReconnaissanceResidentialContext")]
    public partial class SegmentReconnaissanceResidentialContext
    {
        public int SegmentReconnaissanceResidentialContextId { get; set; }

        public int SegmentReconnaissanceId { get; set; }

        public int ResidentialContextId { get; set; }

        public double ResidentialContextPercent { get; set; }

        [StringLength(3000)]
        public string ResidentialContextDesc { get; set; }

        [StringLength(3000)]
        public string ResidentialContextZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual ResidentialContext ResidentialContext { get; set; }

        public virtual SegmentReconnaissance SegmentReconnaissance { get; set; }
    }
}
