namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feature")]
    public partial class Feature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feature()
        {
            AccessLevel = new HashSet<AccessLevel>();
        }

        public int FeatureId { get; set; }

        [StringLength(100)]
        public string FeatureName { get; set; }

        [StringLength(100)]
        public string FeatureZiped { get; set; }

        public bool FeatureIsActive { get; set; }

        public int FeatureTypeId { get; set; }

        public int SubSystemId { get; set; }

        public int? TargetSubSystemId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccessLevel> AccessLevel { get; set; }

        public virtual SubSystem SubSystem { get; set; }

        public virtual SubSystem SubSystem1 { get; set; }
    }
}
