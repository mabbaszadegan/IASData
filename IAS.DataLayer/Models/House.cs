namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            Family = new HashSet<Family>();
            HouseAppliance = new HashSet<HouseAppliance>();
            HouseFamily = new HashSet<HouseFamily>();
        }

        public int HouseId { get; set; }

        [StringLength(50)]
        public string Block { get; set; }

        public int? Floor { get; set; }

        public int? Unit { get; set; }

        public int? BlockCount { get; set; }

        public int? FloorCount { get; set; }

        public int? UnitCountPerFloor { get; set; }

        public int? UnitCount { get; set; }

        [StringLength(50)]
        public string Plaque { get; set; }

        public double? HouseArea { get; set; }

        [Required]
        [StringLength(4000)]
        public string HouseAddress { get; set; }

        [Required]
        [StringLength(4000)]
        public string HouseAddressZiped { get; set; }

        public double? HouseLatitude { get; set; }

        public double? HouseLongitude { get; set; }

        public int? AddressComponentId { get; set; }

        public int? StreetId { get; set; }

        public int? AlleyId { get; set; }

        public int? PlaceTypeId { get; set; }

        public int? HouseTypeId { get; set; }

        public int? HouseBuildingMaterialId { get; set; }

        public int? FuelTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual AddressComponent AddressComponent { get; set; }

        public virtual Alley Alley { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        public virtual FuelType FuelType { get; set; }

        public virtual HouseBuildingMaterial HouseBuildingMaterial { get; set; }

        public virtual HouseType HouseType { get; set; }

        public virtual PlaceType PlaceType { get; set; }

        public virtual Street Street { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseAppliance> HouseAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseFamily> HouseFamily { get; set; }
    }
}
