namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubSystem")]
    public partial class SubSystem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubSystem()
        {
            Feature = new HashSet<Feature>();
            Feature1 = new HashSet<Feature>();
            SubSystem1 = new HashSet<SubSystem>();
        }

        public int SubSystemId { get; set; }

        [Required]
        [StringLength(100)]
        public string SubSystemName { get; set; }

        [StringLength(150)]
        public string ControlName { get; set; }

        [StringLength(100)]
        public string SubSystemIconCss { get; set; }

        public bool SubSystemIsActive { get; set; }

        public int? SubSystemIndex { get; set; }

        public bool SubSystemLoadGrid { get; set; }

        [StringLength(50)]
        public string ReportGroupBy { get; set; }

        [StringLength(50)]
        public string DimensionX { get; set; }

        [StringLength(50)]
        public string DimensionY { get; set; }

        [StringLength(50)]
        public string DimensionXFa { get; set; }

        [StringLength(50)]
        public string DimensionYFa { get; set; }

        [StringLength(2000)]
        public string SubSystemUserGuidePath { get; set; }

        [StringLength(150)]
        public string SubSystemActionOnLoad { get; set; }

        [StringLength(150)]
        public string SubSystemActionOnInsert { get; set; }

        [StringLength(150)]
        public string SubSystemActionOnEdit { get; set; }

        [Required]
        [StringLength(100)]
        public string SubSystemZiped { get; set; }

        public int? ParentId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Feature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Feature1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubSystem> SubSystem1 { get; set; }

        public virtual SubSystem SubSystem2 { get; set; }
    }
}
