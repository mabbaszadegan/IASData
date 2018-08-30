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
    
    public partial class EmployeeHistory
    {
        public int PersonId { get; set; }
        public string PersonCode { get; set; }
        public Nullable<System.DateTime> PersonFilingDate { get; set; }
        public string PersonFilingDateSolar { get; set; }
        public string PersonFilingName { get; set; }
        public Nullable<System.DateTime> PersonCoveredDate { get; set; }
        public string PersonCoveredDateSolar { get; set; }
        public string PersonCoveredDesc { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonFatherName { get; set; }
        public string PersonMotherName { get; set; }
        public string PersonIdentityNo { get; set; }
        public string PersonNationalCode { get; set; }
        public string PersonBirthYear { get; set; }
        public string PersonBirthMonth { get; set; }
        public string PersonBirthDay { get; set; }
        public Nullable<System.DateTime> PersonBirthDate { get; set; }
        public string PersonBirthDateSolar { get; set; }
        public Nullable<decimal> PersonMonthlyIncome { get; set; }
        public Nullable<decimal> PersonMonthlyExpense { get; set; }
        public string PersonDesc { get; set; }
        public string PersonCellPhone1 { get; set; }
        public string PersonCellPhone2 { get; set; }
        public Nullable<int> BankId { get; set; }
        public string PersonBankAccount { get; set; }
        public string PersonBankCard { get; set; }
        public string PersonBankBranch { get; set; }
        public string PersonShirtSize { get; set; }
        public string PersonPantSize { get; set; }
        public string PersonShoesSize { get; set; }
        public Nullable<double> PersonHeight { get; set; }
        public Nullable<double> PersonWeight { get; set; }
        public Nullable<double> PersonBMIIndex { get; set; }
        public string PersonZiped { get; set; }
        public bool PersonHasPassport { get; set; }
        public bool PersonHasCard { get; set; }
        public bool PersonLeavedFamily { get; set; }
        public string PersonLeavedFamilyDateSolar { get; set; }
        public Nullable<System.DateTime> PersonLeavedFamilyDate { get; set; }
        public Nullable<int> PersonLeavingHouseCauseId { get; set; }
        public string PersonLeavingHouseCauseDesc { get; set; }
        public string PersonLeavingHouseDesc { get; set; }
        public string PersonAddress { get; set; }
        public string PersonAddressZiped { get; set; }
        public bool PersonLeavedEducation { get; set; }
        public bool PersonIsWorkedChild { get; set; }
        public Nullable<bool> PersonHasInjectionCard { get; set; }
        public Nullable<bool> PersonGetBlueCard { get; set; }
        public Nullable<bool> PersonCanTraveling { get; set; }
        public string PersonTravelingDesc { get; set; }
        public bool PersonSupportedByOtherNGO { get; set; }
        public string PersonSupportedByOtherNGODesc { get; set; }
        public bool PersonSupportedByIAS { get; set; }
        public Nullable<int> SupportingOrganId { get; set; }
        public int DepartmentId { get; set; }
        public int PersonStatusId { get; set; }
        public Nullable<int> BeliveId { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> EducationTypeId { get; set; }
        public Nullable<int> EducationFieldId { get; set; }
        public Nullable<int> EducationStatusId { get; set; }
        public string EducationDesc { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public Nullable<int> EthnicId { get; set; }
        public Nullable<double> MigrateDuration { get; set; }
        public Nullable<int> BirthProvinceId { get; set; }
        public Nullable<int> BirthCityId { get; set; }
        public string PersonLivelihood { get; set; }
        public Nullable<int> JobStatusId { get; set; }
        public Nullable<int> JobId { get; set; }
        public string JobDesc { get; set; }
        public Nullable<decimal> JobSalary { get; set; }
        public Nullable<int> ChildMarriageCauseId { get; set; }
        public bool PersonHasChildMarriage { get; set; }
        public string PersonChildMarriageDesc { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> HealthTypeId { get; set; }
        public Nullable<int> DrugHistoryId { get; set; }
        public Nullable<int> DrugWithdrawalHistoryId { get; set; }
        public Nullable<int> DrugStatusId { get; set; }
        public Nullable<int> BloodTypeId { get; set; }
        public Nullable<int> InsuranceTypeId { get; set; }
        public string InsuranceDesc { get; set; }
        public string SportTarget { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    }
}
