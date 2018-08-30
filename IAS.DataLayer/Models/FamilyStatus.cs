namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FamilyStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamilyStatus()
        {
            Family = new HashSet<Family>();
        }

        public int FamilyStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string FamilyStatusName { get; set; }

        [StringLength(50)]
        public string FamilyStatusSummaryName { get; set; }

        [StringLength(100)]
        public string FamilyStatusZiped { get; set; }

        public int CountryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
    }
}
