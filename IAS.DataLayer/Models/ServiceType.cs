namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceType")]
    public partial class ServiceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceType()
        {
            PersonSupportingOrganServiceType = new HashSet<PersonSupportingOrganServiceType>();
        }

        public int ServiceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceTypeName { get; set; }

        [StringLength(50)]
        public string ServiceTypeSummaryName { get; set; }

        [StringLength(100)]
        public string ServiceTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSupportingOrganServiceType> PersonSupportingOrganServiceType { get; set; }
    }
}
