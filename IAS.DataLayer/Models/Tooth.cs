namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tooth")]
    public partial class Tooth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tooth()
        {
            PersonToothStatus = new HashSet<PersonToothStatus>();
        }

        public short ToothId { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothIndex { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothEnglishName { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothPersianName { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothSummaryEnglishName { get; set; }

        [Required]
        [StringLength(50)]
        public string ToothSummaryName { get; set; }

        [StringLength(100)]
        public string ToothZiped { get; set; }

        public int ToothTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonToothStatus> PersonToothStatus { get; set; }

        public virtual ToothType ToothType { get; set; }
    }
}
