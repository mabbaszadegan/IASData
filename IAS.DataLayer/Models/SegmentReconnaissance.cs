namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegmentReconnaissance")]
    public partial class SegmentReconnaissance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegmentReconnaissance()
        {
            SegmentReconnaissanceDrugType = new HashSet<SegmentReconnaissanceDrugType>();
            SegmentReconnaissanceEthnic = new HashSet<SegmentReconnaissanceEthnic>();
            SegmentReconnaissanceFuelType = new HashSet<SegmentReconnaissanceFuelType>();
            SegmentReconnaissancePlaceType = new HashSet<SegmentReconnaissancePlaceType>();
            SegmentReconnaissanceResidentialContext = new HashSet<SegmentReconnaissanceResidentialContext>();
        }

        public int SegmentReconnaissanceId { get; set; }

        public int SegmentId { get; set; }

        [Required]
        [StringLength(10)]
        public string SegmentReconnaissanceDateSolar { get; set; }

        public DateTime SegmentReconnaissanceDate { get; set; }

        [StringLength(4000)]
        public string SegmentReconnaissanceDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string SegmentReconnaissanceZiped { get; set; }

        public int? ReconnaissanceCauseId { get; set; }

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

        public virtual PowerSupply PowerSupply { get; set; }

        public virtual ReconnaissanceCause ReconnaissanceCause { get; set; }

        public virtual Segment Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceDrugType> SegmentReconnaissanceDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceEthnic> SegmentReconnaissanceEthnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceFuelType> SegmentReconnaissanceFuelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissancePlaceType> SegmentReconnaissancePlaceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceResidentialContext> SegmentReconnaissanceResidentialContext { get; set; }
    }
}
