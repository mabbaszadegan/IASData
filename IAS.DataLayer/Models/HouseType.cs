namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseType")]
    public partial class HouseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HouseType()
        {
            House = new HashSet<House>();
        }

        public int HouseTypeId { get; set; }

        [Required]
        [StringLength(2000)]
        public string HouseTypeName { get; set; }

        [StringLength(2000)]
        public string HouseTypeDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string HouseTypeZiped { get; set; }

        public bool PlaqueRequired { get; set; }

        public bool BlockRequired { get; set; }

        public bool UnitRequired { get; set; }

        public bool FloorRequired { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }
    }
}
