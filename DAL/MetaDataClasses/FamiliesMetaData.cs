using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamiliesMetaData
    {
        public int FamilyId { get; set; }
        [Display(Name = "شماره پرونده")]
        public string FamilyCode { get; set; }
        public Nullable<decimal> FamilyHealthAmount { get; set; }
        public Nullable<decimal> FamilyRentAmount { get; set; }
        public Nullable<decimal> FamilyMortgageAmount { get; set; }
        public Nullable<decimal> FamilyOtherCostAmount { get; set; }
        public Nullable<decimal> FamilyMonthlyExpense { get; set; }
        public Nullable<decimal> FamilyMonthlyIncome { get; set; }
        [Display(Name = "تلفن 1")]
        public string FamilyPhone1 { get; set; }
        [Display(Name = "نام/ نسبت مالک")]
        public string FamilyPhone1Desc { get; set; }
        [Display(Name = "تلفن 2")]
        public string FamilyPhone2 { get; set; }
        [Display(Name = "نام/ نسبت مالک")]
        public string FamilyPhone2Desc { get; set; }
        [Display(Name = "موبایل 1")]
        public string FamilyCellPhone1 { get; set; }
        [Display(Name = "نام/ نسبت مالک")]
        public string FamilyCellPhone1Desc { get; set; }
        [Display(Name = "موبایل 2")]
        public string FamilyCellPhone2 { get; set; }
        [Display(Name = "نام/ نسبت مالک")]
        public string FamilyCellPhone2Desc { get; set; }
        [Display(Name = "نشانی")]
        public string FamilyAddress { get; set; }
        public Nullable<double> FamilyLatitude { get; set; }
        public Nullable<double> FamilyLongitude { get; set; }
        public string FamilyZiped { get; set; }
        public string FamilyAddressZiped { get; set; }
        public int FamilyMemberCount { get; set; }
        public Nullable<int> PersonId { get; set; }
        [Display(Name = "مدت سکونت در محل")]
        public Nullable<int> ResidenceTypeId { get; set; }
        [Display(Name = "وضعیت مسکن")]
        public Nullable<int> HouseStatusId { get; set; }
        [Display(Name = "نوع مصالح مصرفی")]
        public Nullable<int> HouseBuildingMaterialId { get; set; }
        [Display(Name = "متراژ منزل")]
        public Nullable<double> HouseArea { get; set; }
        [Display(Name = "وضعیت خانوادگی")]
        public Nullable<int> FamilyStatusId { get; set; }
        [Display(Name = "ارجاع دهنده")]
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
        [Display(Name = "فوت شده")]
        public bool FatherIsDied { get; set; }
        [Display(Name = "تاریخ فوت")]
        public string FatherDiedDateSolar { get; set; }
        public Nullable<System.DateTime> FatherDiedDate { get; set; }
        [Display(Name = "علت فوت")]
        public Nullable<int> FatherDiedCauseId { get; set; }
        [Display(Name = "علت فوت")]
        public string FatherDiedCauseDesc { get; set; }
        [Display(Name = "سن فوت")]
        public Nullable<int> FatherDiedAge { get; set; }
        [Display(Name = "ترک خانواده")]
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
        [Display(Name = "سن فوت")]
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
        public Nullable<int> FuelTypeId { get; set; }
        public Nullable<int> ResidentialContextId { get; set; }
        public Nullable<int> WaterSourceId { get; set; }
        public string FamilyDesc { get; set; }


    }


    [MetadataType(typeof(FamiliesMetaData))]
    public partial class Family
    {

    }
}
