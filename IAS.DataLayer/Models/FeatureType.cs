namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeatureType")]
    public partial class FeatureType
    {
        public int FeatureTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FeatureTypeName { get; set; }

        [Required]
        [StringLength(100)]
        public string FeatureTypeNameEnglish { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
