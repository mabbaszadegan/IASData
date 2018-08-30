namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentPlaceType")]
    public partial class SegmentPlaceType
    {
        public int SegmentPlaceTypeId { get; set; }

        public int SegmentId { get; set; }

        public int PlaceTypeId { get; set; }

        [StringLength(3000)]
        public string PlaceTypeDesc { get; set; }

        [StringLength(3000)]
        public string PlaceTypeZiped { get; set; }

        public bool ExistInSegment { get; set; }

        public double? NearlyDistance { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual PlaceType PlaceType { get; set; }

        public virtual Segment Segment { get; set; }
    }
}
