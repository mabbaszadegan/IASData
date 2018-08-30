namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonLog")]
    public partial class PersonLog
    {
        public long PersonLogId { get; set; }

        public int PersonId { get; set; }

        [StringLength(10)]
        public string PersonCode { get; set; }

        public DateTime? PersonFilingDate { get; set; }

        [StringLength(10)]
        public string PersonFilingDateSolar { get; set; }

        [StringLength(50)]
        public string PersonFilingName { get; set; }

        public DateTime? PersonCoveredDate { get; set; }

        [StringLength(10)]
        public string PersonCoveredDateSolar { get; set; }

        [StringLength(50)]
        public string PersonCoveredDesc { get; set; }

        [StringLength(50)]
        public string PersonFirstName { get; set; }

        [StringLength(500)]
        public string PersonLastName { get; set; }

        [StringLength(500)]
        public string PersonFatherName { get; set; }

        [StringLength(10)]
        public string PersonIdentityNo { get; set; }

        [StringLength(10)]
        public string PersonNationalCode { get; set; }

        [StringLength(4)]
        public string PersonBirthYear { get; set; }

        [StringLength(2)]
        public string PersonBirthMonth { get; set; }

        [StringLength(2)]
        public string PersonBirthDay { get; set; }

        public DateTime? PersonBirthDate { get; set; }

        [StringLength(10)]
        public string PersonBirthDateSolar { get; set; }

        [Column(TypeName = "money")]
        public decimal? PersonMonthlyIncome { get; set; }

        [Column(TypeName = "money")]
        public decimal? PersonMonthlyExpense { get; set; }

        public string PersonDesc { get; set; }

        [StringLength(50)]
        public string PersonCellPhone1 { get; set; }

        [StringLength(50)]
        public string PersonCellPhone2 { get; set; }

        public int? BankId { get; set; }

        [StringLength(50)]
        public string PersonBankAccount { get; set; }

        [StringLength(50)]
        public string PersonBankCard { get; set; }

        [StringLength(50)]
        public string PersonBankBranch { get; set; }

        [StringLength(50)]
        public string PersonShirtSize { get; set; }

        [StringLength(50)]
        public string PersonPantSize { get; set; }

        [StringLength(50)]
        public string PersonShoesSize { get; set; }

        public double? PersonHeight { get; set; }

        public double? PersonWeight { get; set; }

        [StringLength(4000)]
        public string PersonZiped { get; set; }

        public bool PersonHasPassport { get; set; }

        public bool PersonHasCard { get; set; }

        public bool PersonLeavedFamily { get; set; }

        public bool PersonLeavedEducation { get; set; }

        public bool PersonIsWorkedChild { get; set; }

        public bool? PersonHasInjectionCard { get; set; }

        public bool? PersonGetBlueCard { get; set; }

        public bool? PersonCanTraveling { get; set; }

        [StringLength(4000)]
        public string PersonTravelingDesc { get; set; }

        public bool PersonSupportedByOtherNGO { get; set; }

        [StringLength(4000)]
        public string PersonSupportedByOtherNGODesc { get; set; }

        public bool PersonSupportedByIAS { get; set; }

        public int? SupportingOrganId { get; set; }

        public int DepartmentId { get; set; }

        public int PersonStatusId { get; set; }

        public int? BeliveId { get; set; }

        public int? ReligionId { get; set; }

        public int? GenderId { get; set; }

        public int? EducationTypeId { get; set; }

        public int? EducationFieldId { get; set; }

        public int? NationalityId { get; set; }

        public double? MigrateDuration { get; set; }

        public int? BirthProvinceId { get; set; }

        public int? BirthCityId { get; set; }

        [StringLength(2000)]
        public string PersonLivelihood { get; set; }

        public int? JobStatusId { get; set; }

        public int? JobId { get; set; }

        [StringLength(4000)]
        public string JobDesc { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? HealthTypeId { get; set; }

        public int? DrugHistoryId { get; set; }

        public int? DrugStatusId { get; set; }

        public int? InsuranceTypeId { get; set; }

        [StringLength(4000)]
        public string InsuranceDesc { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? BloodTypeId { get; set; }

        public int? ChildMarriageCauseId { get; set; }

        public int? DrugWithdrawalHistoryId { get; set; }

        [StringLength(2000)]
        public string EducationDesc { get; set; }

        public int? EducationStatusId { get; set; }

        public int? EthnicId { get; set; }

        [StringLength(2000)]
        public string PersonAddress { get; set; }

        [StringLength(2000)]
        public string PersonAddressZiped { get; set; }

        public double? PersonBMIIndex { get; set; }

        [StringLength(2000)]
        public string PersonChildMarriageDesc { get; set; }

        public bool PersonHasChildMarriage { get; set; }

        [StringLength(10)]
        public string PersonLeavedFamilyDateSolar { get; set; }

        public DateTime? PersonLeavedFamilyDate { get; set; }

        public int? PersonLeavingHouseCauseId { get; set; }

        [StringLength(500)]
        public string PersonLeavingHouseCauseDesc { get; set; }

        [StringLength(500)]
        public string PersonLeavingHouseDesc { get; set; }

        [StringLength(4000)]
        public string SportTarget { get; set; }

        public virtual Person Person { get; set; }
    }
}
