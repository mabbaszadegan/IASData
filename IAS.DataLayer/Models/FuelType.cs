namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelType")]
    public partial class FuelType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FuelType()
        {
            DepartmentFuelType = new HashSet<DepartmentFuelType>();
            House = new HashSet<House>();
            SegmentFuelType = new HashSet<SegmentFuelType>();
            SegmentReconnaissanceFuelType = new HashSet<SegmentReconnaissanceFuelType>();
        }

        public int FuelTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FuelTypeName { get; set; }

        [StringLength(2000)]
        public string FuelTypeDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string FuelTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentFuelType> DepartmentFuelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentFuelType> SegmentFuelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceFuelType> SegmentReconnaissanceFuelType { get; set; }
    }
}
