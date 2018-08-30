namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupportingOrgan")]
    public partial class SupportingOrgan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupportingOrgan()
        {
            DepartmentSupportingOrgan = new HashSet<DepartmentSupportingOrgan>();
            Person = new HashSet<Person>();
            PersonSupportingOrgan = new HashSet<PersonSupportingOrgan>();
        }

        public int SupportingOrganId { get; set; }

        [Required]
        [StringLength(50)]
        public string SupportingOrganName { get; set; }

        [StringLength(50)]
        public string SupportingOrganSummaryName { get; set; }

        [StringLength(100)]
        public string SupportingOrganZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSupportingOrgan> DepartmentSupportingOrgan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSupportingOrgan> PersonSupportingOrgan { get; set; }
    }
}
