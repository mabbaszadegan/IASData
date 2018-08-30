namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlaceType")]
    public partial class PlaceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlaceType()
        {
            House = new HashSet<House>();
            SegmentPlaceType = new HashSet<SegmentPlaceType>();
            SegmentReconnaissancePlaceType = new HashSet<SegmentReconnaissancePlaceType>();
        }

        public int PlaceTypeId { get; set; }

        [Required]
        [StringLength(2000)]
        public string PlaceTypeName { get; set; }

        [StringLength(2000)]
        public string PlaceTypeDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string PlaceTypeZiped { get; set; }

        public bool PlaqueRequired { get; set; }

        public bool BlockRequired { get; set; }

        public bool UnitRequired { get; set; }

        public bool FloorRequired { get; set; }

        public int PlaceCategoryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }

        public virtual PlaceCategory PlaceCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentPlaceType> SegmentPlaceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissancePlaceType> SegmentReconnaissancePlaceType { get; set; }
    }
}
