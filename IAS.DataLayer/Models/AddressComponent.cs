namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressComponent")]
    public partial class AddressComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressComponent()
        {
            AddressComponent1 = new HashSet<AddressComponent>();
            House = new HashSet<House>();
        }

        public int AddressComponentId { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressComponentName { get; set; }

        [StringLength(2000)]
        public string AddressComponentDesc { get; set; }

        [StringLength(2000)]
        public string AddressComponentZiped { get; set; }

        public int AddressComponentTypeId { get; set; }

        public int SegmentId { get; set; }

        public int ParentId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressComponent> AddressComponent1 { get; set; }

        public virtual AddressComponent AddressComponent2 { get; set; }

        public virtual AddressComponentType AddressComponentType { get; set; }

        public virtual Segment Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }
    }
}
