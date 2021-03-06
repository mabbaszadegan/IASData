//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            this.Family = new HashSet<Family>();
            this.HouseAppliance = new HashSet<HouseAppliance>();
            this.HouseFamily = new HashSet<HouseFamily>();
        }
    
        public int HouseId { get; set; }
        public string Block { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<int> BlockCount { get; set; }
        public Nullable<int> FloorCount { get; set; }
        public Nullable<int> UnitCountPerFloor { get; set; }
        public Nullable<int> UnitCount { get; set; }
        public string Plaque { get; set; }
        public Nullable<double> HouseArea { get; set; }
        public string HouseAddress { get; set; }
        public string HouseAddressZiped { get; set; }
        public Nullable<double> HouseLatitude { get; set; }
        public Nullable<double> HouseLongitude { get; set; }
        public Nullable<int> AddressComponentId { get; set; }
        public Nullable<int> StreetId { get; set; }
        public Nullable<int> AlleyId { get; set; }
        public Nullable<int> PlaceTypeId { get; set; }
        public Nullable<int> HouseTypeId { get; set; }
        public Nullable<int> HouseBuildingMaterialId { get; set; }
        public Nullable<int> FuelTypeId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
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
