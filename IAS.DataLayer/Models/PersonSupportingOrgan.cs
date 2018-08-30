namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSupportingOrgan")]
    public partial class PersonSupportingOrgan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonSupportingOrgan()
        {
            PersonSupportingOrganServiceType = new HashSet<PersonSupportingOrganServiceType>();
        }

        public int PersonSupportingOrganId { get; set; }

        public int PersonId { get; set; }

        public int SupportingOrganId { get; set; }

        [StringLength(50)]
        public string SupportingOrganName { get; set; }

        public double? SupportingDuration { get; set; }

        [StringLength(500)]
        public string SupportingCause { get; set; }

        [StringLength(2000)]
        public string SupportingDesc { get; set; }

        [StringLength(2000)]
        public string SupportingZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual SupportingOrgan SupportingOrgan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSupportingOrganServiceType> PersonSupportingOrganServiceType { get; set; }
    }
}
