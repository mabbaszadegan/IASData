namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseInfo")]
    public partial class BaseInfo
    {
        public int BaseInfoId { get; set; }

        [Required]
        [StringLength(5)]
        public string BaseInfoCode { get; set; }

        [Required]
        [StringLength(4000)]
        public string BaseInfoName { get; set; }

        [Required]
        [StringLength(500)]
        public string BaseInfoSummaryName { get; set; }

        public int BaseInfoIndex { get; set; }

        [StringLength(4000)]
        public string BaseInfoDesc { get; set; }

        [StringLength(50)]
        public string BaseInfoValue { get; set; }

        [Required]
        [StringLength(4000)]
        public string BaseInfoZiped { get; set; }

        public bool BaseInfoIsActive { get; set; }

        public int BaseInfoGroupId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual BaseInfoGroup BaseInfoGroup { get; set; }
    }
}
