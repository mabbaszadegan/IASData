namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressComponentType")]
    public partial class AddressComponentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressComponentType()
        {
            AddressComponent = new HashSet<AddressComponent>();
        }

        public int AddressComponentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressComponentTypeName { get; set; }

        [StringLength(50)]
        public string AddressComponentTypeSummaryName { get; set; }

        [StringLength(100)]
        public string AddressComponentTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressComponent> AddressComponent { get; set; }
    }
}
