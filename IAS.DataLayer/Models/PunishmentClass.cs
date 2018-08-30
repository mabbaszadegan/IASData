namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PunishmentClass")]
    public partial class PunishmentClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PunishmentClass()
        {
            PunishmentType = new HashSet<PunishmentType>();
        }

        public int PunishmentClassId { get; set; }

        [Required]
        [StringLength(50)]
        public string PunishmentClassName { get; set; }

        [StringLength(50)]
        public string PunishmentClassSummaryName { get; set; }

        [StringLength(100)]
        public string PunishmentClassZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PunishmentType> PunishmentType { get; set; }
    }
}
