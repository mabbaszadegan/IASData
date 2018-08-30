namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Referrer")]
    public partial class Referrer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Referrer()
        {
            DepartmentReferrer = new HashSet<DepartmentReferrer>();
            Family = new HashSet<Family>();
        }

        public int ReferrerId { get; set; }

        [Required]
        [StringLength(50)]
        public string ReferrerName { get; set; }

        [StringLength(50)]
        public string ReferrerSummaryName { get; set; }

        [StringLength(100)]
        public string ReferrerZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentReferrer> DepartmentReferrer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
    }
}
