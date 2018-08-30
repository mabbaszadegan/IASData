namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityField")]
    public partial class ActivityField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityField()
        {
            PersonnelActivityField = new HashSet<PersonnelActivityField>();
        }

        public int ActivityFieldId { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityFieldName { get; set; }

        [StringLength(50)]
        public string ActivityFieldSummaryName { get; set; }

        [StringLength(100)]
        public string ActivityFieldZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelActivityField> PersonnelActivityField { get; set; }
    }
}
