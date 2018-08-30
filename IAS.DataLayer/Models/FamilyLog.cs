namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyLog")]
    public partial class FamilyLog
    {
        public int FamilyLogId { get; set; }

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

        [Required]
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

        [StringLength(4000)]
        public string FamilyDesc { get; set; }

        public virtual Family Family { get; set; }
    }
}
