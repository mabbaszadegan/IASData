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
    
    public partial class FamilyLog
    {
        public int FamilyLogId { get; set; }
        public int FamilyId { get; set; }
        public string FamilyCode { get; set; }
        public Nullable<decimal> FamilyHealthAmount { get; set; }
        public Nullable<decimal> FamilyRentAmount { get; set; }
        public Nullable<decimal> FamilyMortgageAmount { get; set; }
        public Nullable<decimal> FamilyOtherCostAmount { get; set; }
        public Nullable<decimal> FamilyMonthlyExpense { get; set; }
        public Nullable<decimal> FamilyMonthlyIncome { get; set; }
        public string FamilyPhone1 { get; set; }
        public string FamilyPhone1Desc { get; set; }
        public string FamilyPhone2 { get; set; }
        public string FamilyPhone2Desc { get; set; }
        public string FamilyCellPhone1 { get; set; }
        public string FamilyCellPhone1Desc { get; set; }
        public string FamilyCellPhone2 { get; set; }
        public string FamilyCellPhone2Desc { get; set; }
        public string FamilyAddress { get; set; }
        public Nullable<double> FamilyLatitude { get; set; }
        public Nullable<double> FamilyLongitude { get; set; }
        public string FamilyZiped { get; set; }
        public string FamilyAddressZiped { get; set; }
        public int FamilyMemberCount { get; set; }
        public Nullable<int> PersonId { get; set; }
        public Nullable<int> ResidenceTypeId { get; set; }
        public Nullable<int> HouseStatusId { get; set; }
        public Nullable<int> HouseBuildingMaterialId { get; set; }
        public Nullable<double> HouseArea { get; set; }
        public Nullable<int> FamilyStatusId { get; set; }
        public Nullable<int> ReferrerId { get; set; }
        public Nullable<int> SegmentId { get; set; }
        public Nullable<int> StreetId { get; set; }
        public Nullable<int> AlleyId { get; set; }
        public string Plaque { get; set; }
        public Nullable<int> HouseId { get; set; }
        public string GuardianName { get; set; }
        public Nullable<int> GuardianRelationTypeId { get; set; }
        public string GuardianRelationTypeDesc { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianCellPhone { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianAddressZiped { get; set; }
        public bool ParentsHaveDifferentNationality { get; set; }
        public bool ParentsHaveDifferentEthnic { get; set; }
        public Nullable<int> ParentsMaritalStatusId { get; set; }
        public bool FatherIsDied { get; set; }
        public string FatherDiedDateSolar { get; set; }
        public Nullable<System.DateTime> FatherDiedDate { get; set; }
        public Nullable<int> FatherDiedCauseId { get; set; }
        public string FatherDiedCauseDesc { get; set; }
        public Nullable<int> FatherDiedAge { get; set; }
        public bool FatherIsLeavedFamily { get; set; }
        public string FatherLeavedFamilyDateSolar { get; set; }
        public Nullable<System.DateTime> FatherLeavedFamilyDate { get; set; }
        public Nullable<int> FatherLeavingHouseCauseId { get; set; }
        public string FatherLeavingHouseCauseDesc { get; set; }
        public string FatherAddress { get; set; }
        public string FatherAddressZiped { get; set; }
        public bool MotherIsDied { get; set; }
        public string MotherDiedDateSolar { get; set; }
        public Nullable<System.DateTime> MotherDiedDate { get; set; }
        public Nullable<int> MotherDiedCauseId { get; set; }
        public string MotherDiedCauseDesc { get; set; }
        public Nullable<int> MotherDiedAge { get; set; }
        public bool MotherIsLeavedFamily { get; set; }
        public string MotherLeavedFamilyDateSolar { get; set; }
        public Nullable<System.DateTime> MotherLeavedFamilyDate { get; set; }
        public Nullable<int> MotherLeavingHouseCauseId { get; set; }
        public string MotherLeavingHouseCauseDesc { get; set; }
        public string MotherAddress { get; set; }
        public string MotherAddressZiped { get; set; }
        public bool MotherIsPregnant { get; set; }
        public bool FamilyIsMigrated { get; set; }
        public Nullable<int> MigrationCauseId { get; set; }
        public Nullable<short> MigrationYear { get; set; }
        public string MigrationDesc { get; set; }
        public bool FamilyHasDomesticViolence { get; set; }
        public string FamilyHasDomesticViolenceDesc { get; set; }
        public bool HasGas { get; set; }
        public bool HasPower { get; set; }
        public Nullable<int> PowerSupplyId { get; set; }
        public string PowerSupplyDesc { get; set; }
        public bool HasMobileSignal { get; set; }
        public bool HasInternetAccess { get; set; }
        public string SegmentDesc { get; set; }
        public Nullable<double> DrinkingWaterNearlyDistance { get; set; }
        public bool HasDrinkingWater { get; set; }
        public string DrinkingWaterDesc { get; set; }
        public bool SewageSystem { get; set; }
        public string SewageSystemDesc { get; set; }
        public bool WasteCollectionSystem { get; set; }
        public string WasteCollectionSystemDesc { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string FamilyDesc { get; set; }
    
        public virtual Family Family { get; set; }
    }
}
