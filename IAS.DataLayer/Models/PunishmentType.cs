namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PunishmentType")]
    public partial class PunishmentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PunishmentType()
        {
            PersonCrimeType = new HashSet<PersonCrimeType>();
        }

        public int PunishmentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string PunishmentTypeName { get; set; }

        [StringLength(50)]
        public string PunishmentTypeSummaryName { get; set; }

        [StringLength(100)]
        public string PunishmentTypeZiped { get; set; }

        public int PunishmentClassId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCrimeType> PersonCrimeType { get; set; }

        public virtual PunishmentClass PunishmentClass { get; set; }
    }
}
