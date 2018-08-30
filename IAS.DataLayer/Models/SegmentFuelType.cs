namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentFuelType")]
    public partial class SegmentFuelType
    {
        public int SegmentFuelTypeId { get; set; }

        public int SegmentId { get; set; }

        public int FuelTypeId { get; set; }

        public double FuelTypePercent { get; set; }

        [StringLength(3000)]
        public string FuelTypeDesc { get; set; }

        [StringLength(3000)]
        public string FuelTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual FuelType FuelType { get; set; }

        public virtual Segment Segment { get; set; }
    }
}
