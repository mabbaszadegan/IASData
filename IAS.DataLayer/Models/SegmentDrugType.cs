namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentDrugType")]
    public partial class SegmentDrugType
    {
        public int SegmentDrugTypeId { get; set; }

        public int SegmentId { get; set; }

        public int DrugTypeId { get; set; }

        public double DrugTypePercent { get; set; }

        [StringLength(3000)]
        public string DrugTypeDesc { get; set; }

        [StringLength(3000)]
        public string DrugTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DrugType DrugType { get; set; }

        public virtual Segment Segment { get; set; }
    }
}
