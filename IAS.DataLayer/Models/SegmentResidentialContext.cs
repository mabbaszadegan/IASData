namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentResidentialContext")]
    public partial class SegmentResidentialContext
    {
        public int SegmentResidentialContextId { get; set; }

        public int SegmentId { get; set; }

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

        public virtual Segment Segment { get; set; }
    }
}
