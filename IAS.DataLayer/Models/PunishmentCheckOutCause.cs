namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PunishmentCheckOutCause")]
    public partial class PunishmentCheckOutCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PunishmentCheckOutCause()
        {
            PersonCrimeType = new HashSet<PersonCrimeType>();
        }

        public int PunishmentCheckOutCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string PunishmentCheckOutCauseName { get; set; }

        [StringLength(50)]
        public string PunishmentCheckOutCauseSummaryName { get; set; }

        [StringLength(100)]
        public string PunishmentCheckOutCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCrimeType> PersonCrimeType { get; set; }
    }
}
