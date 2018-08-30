namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Segment")]
    public partial class Segment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Segment()
        {
            AddressComponent = new HashSet<AddressComponent>();
            DepartmentSegment = new HashSet<DepartmentSegment>();
            Family = new HashSet<Family>();
            SegmentDrugType = new HashSet<SegmentDrugType>();
            SegmentEthnic = new HashSet<SegmentEthnic>();
            SegmentFuelType = new HashSet<SegmentFuelType>();
            SegmentPlaceType = new HashSet<SegmentPlaceType>();
            SegmentReconnaissance = new HashSet<SegmentReconnaissance>();
            SegmentResidentialContext = new HashSet<SegmentResidentialContext>();
            SegmentWaterSource = new HashSet<SegmentWaterSource>();
            Street = new HashSet<Street>();
        }

        public int SegmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string SegmentName { get; set; }

        [StringLength(50)]
        public string SegmentSummaryName { get; set; }

        [StringLength(100)]
        public string SegmentZiped { get; set; }

        public int RegionId { get; set; }

        public int? FamilyCount { get; set; }

        public int? PersonCount { get; set; }

        public int? ChildrenCount { get; set; }

        public bool HasGas { get; set; }

        public bool HasPower { get; set; }

        public int? PowerSupplyId { get; set; }

        [StringLength(500)]
        public string PowerSupplyDesc { get; set; }

        public bool HasMobileSignal { get; set; }

        public bool HasInternetAccess { get; set; }

        [StringLength(2000)]
        public string SegmentDesc { get; set; }

        public double? DrinkingWaterNearlyDistance { get; set; }

        public bool HasDrinkingWater { get; set; }

        [StringLength(500)]
        public string DrinkingWaterDesc { get; set; }

        public bool SewageSystem { get; set; }

        [StringLength(500)]
        public string SewageSystemDesc { get; set; }

        public bool WasteCollectionSystem { get; set; }

        [StringLength(500)]
        public string WasteCollectionSystemDesc { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressComponent> AddressComponent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSegment> DepartmentSegment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentDrugType> SegmentDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentEthnic> SegmentEthnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentFuelType> SegmentFuelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentPlaceType> SegmentPlaceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissance> SegmentReconnaissance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentResidentialContext> SegmentResidentialContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentWaterSource> SegmentWaterSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Street { get; set; }
    }
}
