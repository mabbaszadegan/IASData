namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MigrationCause")]
    public partial class MigrationCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MigrationCause()
        {
            Family = new HashSet<Family>();
        }

        public int MigrationCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string MigrationCauseName { get; set; }

        [StringLength(50)]
        public string MigrationCauseSummaryName { get; set; }

        [StringLength(100)]
        public string MigrationCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
    }
}
