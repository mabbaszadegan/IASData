namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ToothStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToothStatus()
        {
            PersonToothStatus = new HashSet<PersonToothStatus>();
        }

        public int ToothStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothStatusName { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothStatusSummaryName { get; set; }

        [StringLength(100)]
        public string ToothStatusZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonToothStatus> PersonToothStatus { get; set; }
    }
}
