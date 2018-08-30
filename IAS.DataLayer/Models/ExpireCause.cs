namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExpireCause")]
    public partial class ExpireCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpireCause()
        {
            FamilyMember = new HashSet<FamilyMember>();
        }

        public int ExpireCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpireCauseName { get; set; }

        [StringLength(50)]
        public string ExpireCauseSummaryName { get; set; }

        [StringLength(4000)]
        public string ExpireCauseDesc { get; set; }

        [StringLength(4000)]
        public string ExpireCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMember { get; set; }
    }
}
