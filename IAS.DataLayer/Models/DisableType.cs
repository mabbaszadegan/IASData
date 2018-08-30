namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DisableType")]
    public partial class DisableType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisableType()
        {
            DepartmentDisableType = new HashSet<DepartmentDisableType>();
            PersonDisableType = new HashSet<PersonDisableType>();
        }

        public int DisableTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DisableTypeName { get; set; }

        [StringLength(50)]
        public string DisableTypeSummaryName { get; set; }

        [StringLength(100)]
        public string DisableTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentDisableType> DepartmentDisableType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDisableType> PersonDisableType { get; set; }
    }
}
