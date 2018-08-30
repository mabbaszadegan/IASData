namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessLevel")]
    public partial class AccessLevel
    {
        public int AccessLevelId { get; set; }

        public int RoleId { get; set; }

        public int FeatureId { get; set; }

        public DateTime InsertTime { get; set; }

        public int InsertUserId { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual Role Role { get; set; }
    }
}
