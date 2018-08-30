namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentReconnaissanceEthnic")]
    public partial class SegmentReconnaissanceEthnic
    {
        public int SegmentReconnaissanceEthnicId { get; set; }

        public int SegmentReconnaissanceId { get; set; }

        public int EthnicId { get; set; }

        public double EthnicPercent { get; set; }

        [StringLength(3000)]
        public string EthnicDesc { get; set; }

        [StringLength(3000)]
        public string EthnicZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Ethnic Ethnic { get; set; }

        public virtual SegmentReconnaissance SegmentReconnaissance { get; set; }
    }
}
