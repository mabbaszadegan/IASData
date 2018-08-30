namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PowerSupply")]
    public partial class PowerSupply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PowerSupply()
        {
            DepartmentPowerSupply = new HashSet<DepartmentPowerSupply>();
            SegmentReconnaissance = new HashSet<SegmentReconnaissance>();
        }

        public int PowerSupplyId { get; set; }

        [Required]
        [StringLength(50)]
        public string PowerSupplyName { get; set; }

        [StringLength(2000)]
        public string PowerSupplyDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string PowerSupplyZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentPowerSupply> DepartmentPowerSupply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissance> SegmentReconnaissance { get; set; }
    }
}
