namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentReconnaissanceFuelType")]
    public partial class SegmentReconnaissanceFuelType
    {
        public int SegmentReconnaissanceFuelTypeId { get; set; }

        public int SegmentReconnaissanceId { get; set; }

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

        public virtual SegmentReconnaissance SegmentReconnaissance { get; set; }
    }
}
