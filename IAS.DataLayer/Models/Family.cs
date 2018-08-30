namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Family")]
    public partial class Family
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Family()
        {
            FamilyAppliance = new HashSet<FamilyAppliance>();
            FamilyLog = new HashSet<FamilyLog>();
            FamilyMember = new HashSet<FamilyMember>();
            FamilyPhone = new HashSet<FamilyPhone>();
            FamilyReconnaissance = new HashSet<FamilyReconnaissance>();
            HouseFamily = new HashSet<HouseFamily>();
        }

        public int FamilyId { get; set; }

        [StringLength(50)]
        public string FamilyCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyHealthAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyRentAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyMortgageAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyOtherCostAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyMonthlyExpense { get; set; }

        [Column(TypeName = "money")]
        public decimal? FamilyMonthlyIncome { get; set; }

        [StringLength(30)]
        public string FamilyPhone1 { get; set; }

        [StringLength(300)]
        public string FamilyPhone1Desc { get; set; }

        [StringLength(30)]
        public string FamilyPhone2 { get; set; }

        [StringLength(300)]
        public string FamilyPhone2Desc { get; set; }

        [StringLength(30)]
        public string FamilyCellPhone1 { get; set; }

        [StringLength(300)]
        public string FamilyCellPhone1Desc { get; set; }

        [StringLength(30)]
        public string FamilyCellPhone2 { get; set; }

        [StringLength(300)]
        public string FamilyCellPhone2Desc { get; set; }

        [Required]
        [StringLength(2000)]
        public string FamilyAddress { get; set; }

        public double? FamilyLatitude { get; set; }

        public double? FamilyLongitude { get; set; }

        [Required]
        [StringLength(4000)]
        public string FamilyZiped { get; set; }

        [Required]
        [StringLength(4000)]
        public string FamilyAddressZiped { get; set; }

        public int FamilyMemberCount { get; set; }

        public int? PersonId { get; set; }

        public int? ResidenceTypeId { get; set; }

        public int? HouseStatusId { get; set; }

        public int? HouseBuildingMaterialId { get; set; }

        public double? HouseArea { get; set; }

        public int? FamilyStatusId { get; set; }

        public int? ReferrerId { get; set; }

        public int? SegmentId { get; set; }

        public int? StreetId { get; set; }

        public int? AlleyId { get; set; }

        [StringLength(200)]
        public string Plaque { get; set; }

        public int? HouseId { get; set; }

        [StringLength(200)]
        public string GuardianName { get; set; }

        public int? GuardianRelationTypeId { get; set; }

        [StringLength(200)]
        public string GuardianRelationTypeDesc { get; set; }

        [StringLength(200)]
        public string GuardianPhone { get; set; }

        [StringLength(200)]
        public string GuardianCellPhone { get; set; }

        [StringLength(2000)]
        public string GuardianAddress { get; set; }

        [StringLength(2000)]
        public string GuardianAddressZiped { get; set; }

        public bool ParentsHaveDifferentNationality { get; set; }

        public bool ParentsHaveDifferentEthnic { get; set; }

        public int? ParentsMaritalStatusId { get; set; }

        public bool FatherIsDied { get; set; }

        [StringLength(10)]
        public string FatherDiedDateSolar { get; set; }

        public DateTime? FatherDiedDate { get; set; }

        public int? FatherDiedCauseId { get; set; }

        [StringLength(500)]
        public string FatherDiedCauseDesc { get; set; }

        public int? FatherDiedAge { get; set; }

        public bool FatherIsLeavedFamily { get; set; }

        [StringLength(10)]
        public string FatherLeavedFamilyDateSolar { get; set; }

        public DateTime? FatherLeavedFamilyDate { get; set; }

        public int? FatherLeavingHouseCauseId { get; set; }

        [StringLength(500)]
        public string FatherLeavingHouseCauseDesc { get; set; }

        [StringLength(2000)]
        public string FatherAddress { get; set; }

        [StringLength(2000)]
        public string FatherAddressZiped { get; set; }

        public bool MotherIsDied { get; set; }

        [StringLength(10)]
        public string MotherDiedDateSolar { get; set; }

        public DateTime? MotherDiedDate { get; set; }

        public int? MotherDiedCauseId { get; set; }

        [StringLength(500)]
        public string MotherDiedCauseDesc { get; set; }

        public int? MotherDiedAge { get; set; }

        public bool MotherIsLeavedFamily { get; set; }

        [StringLength(10)]
        public string MotherLeavedFamilyDateSolar { get; set; }

        public DateTime? MotherLeavedFamilyDate { get; set; }

        public int? MotherLeavingHouseCauseId { get; set; }

        [StringLength(500)]
        public string MotherLeavingHouseCauseDesc { get; set; }

        [StringLength(2000)]
        public string MotherAddress { get; set; }

        [StringLength(2000)]
        public string MotherAddressZiped { get; set; }

        public bool MotherIsPregnant { get; set; }

        public bool FamilyIsMigrated { get; set; }

        public int? MigrationCauseId { get; set; }

        public short? MigrationYear { get; set; }

        [StringLength(2000)]
        public string MigrationDesc { get; set; }

        public bool FamilyHasDomesticViolence { get; set; }

        [StringLength(2000)]
        public string FamilyHasDomesticViolenceDesc { get; set; }

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

        public int? FuelTypeId { get; set; }

        public int? ResidentialContextId { get; set; }

        public int? WaterSourceId { get; set; }

        [StringLength(4000)]
        public string FamilyDesc { get; set; }

        public virtual Alley Alley { get; set; }

        public virtual DiedCause DiedCause { get; set; }

        public virtual DiedCause DiedCause1 { get; set; }

        public virtual FamilyStatus FamilyStatus { get; set; }

        public virtual House House { get; set; }

        public virtual HouseBuildingMaterial HouseBuildingMaterial { get; set; }

        public virtual HouseStatus HouseStatus { get; set; }

        public virtual LeavingHouseCause LeavingHouseCause { get; set; }

        public virtual LeavingHouseCause LeavingHouseCause1 { get; set; }

        public virtual MaritalStatus MaritalStatus { get; set; }

        public virtual MigrationCause MigrationCause { get; set; }

        public virtual Person Person { get; set; }

        public virtual Referrer Referrer { get; set; }

        public virtual RelationType RelationType { get; set; }

        public virtual ResidenceType ResidenceType { get; set; }

        public virtual Segment Segment { get; set; }

        public virtual Street Street { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyAppliance> FamilyAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyLog> FamilyLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyPhone> FamilyPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyReconnaissance> FamilyReconnaissance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseFamily> HouseFamily { get; set; }
    }
}
