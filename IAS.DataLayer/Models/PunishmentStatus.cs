namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PunishmentStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PunishmentStatus()
        {
            PersonCrimeType = new HashSet<PersonCrimeType>();
        }

        public int PunishmentStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string PunishmentStatusName { get; set; }

        [StringLength(50)]
        public string PunishmentStatusSummaryName { get; set; }

        [StringLength(100)]
        public string PunishmentStatusZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCrimeType> PersonCrimeType { get; set; }
    }
}
