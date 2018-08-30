using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonsMetaData
    {
        public int PersonId { get; set; }

        [Display(Name = "شماره پرونده")]
        public string PersonCode { get; set; }
        public Nullable<System.DateTime> PersonFilingDate { get; set; }
        [Display(Name = "تاریخ شناسایی")]
        public string PersonFilingDateSolar { get; set; }
        [Display(Name = "سرپرست تیم شناسایی")]
        public string PersonFilingName { get; set; }
        public Nullable<System.DateTime> PersonCoveredDate { get; set; }
        [Display(Name = "تاریخ شروع حمایت")]
        public string PersonCoveredDateSolar { get; set; }
        [Display(Name = "توضیحات")]
        public string PersonCoveredDesc { get; set; }
        [Display(Name = "نام")]
        [Required( ErrorMessage ="{0} ضروری است")]
        public string PersonFirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required( ErrorMessage ="{0} ضروری است")]
        public string PersonLastName { get; set; }
        [Display(Name = "نام پدر")]
        public string PersonFatherName { get; set; }
        [Display(Name = "نام مادر")]
        public string PersonMotherName { get; set; }
        [Display(Name = "شماره شناسنامه")]
        public string PersonIdentityNo { get; set; }
        [Display(Name = "کدملی")]
        [MaxLength(10)]
        public string PersonNationalCode { get; set; }
        [Display(Name = "سال تولد")]
        [MaxLength(4)]
        public string PersonBirthYear { get; set; }
        [Display(Name = "ماه تولد")]
        [MaxLength(2)]
        public string PersonBirthMonth { get; set; }
        [Display(Name = "روز تولد")]
        [MaxLength(2)]
        public string PersonBirthDay { get; set; }
        public Nullable<System.DateTime> PersonBirthDate { get; set; }
        [Display(Name = "تاریخ تولد")]
        public string PersonBirthDateSolar { get; set; }
        public Nullable<decimal> PersonMonthlyIncome { get; set; }
        public Nullable<decimal> PersonMonthlyExpense { get; set; }
        [Display(Name = "توضیحات تکمیلی")]
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
        [Display(Name = "تاریخ ترک خانواده")]
        public string PersonLeavedFamilyDateSolar { get; set; }
        public Nullable<System.DateTime> PersonLeavedFamilyDate { get; set; }
        [Display(Name = "علت ترک خانواده")]
        public Nullable<int> PersonLeavingHouseCauseId { get; set; }
        [Display(Name = "علت ترک خانواده")]
        public string PersonLeavingHouseCauseDesc { get; set; }
        [Display(Name = "توضیحات تکمیلی درباره ترک خانواده")]
        public string PersonLeavingHouseDesc { get; set; }
        [Display(Name = "نشانی محل زندگی بعد از ترک خانواده")]
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
        [Display(Name = "نمایندگی")]
        public int DepartmentId { get; set; }
        [Display(Name = "وضعیت")]
        [Required( ErrorMessage ="{0} ضروری است")]
        public int PersonStatusId { get; set; }
        [Display(Name = "دین")]
        public Nullable<int> BeliveId { get; set; }
        [Display(Name = "مذهب")]
        public Nullable<int> ReligionId { get; set; }
        [Display(Name = "جنسیت")]
        public Nullable<int> GenderId { get; set; }
        [Display(Name = "تحصیلات")]
        public Nullable<int> EducationTypeId { get; set; }
        [Display(Name = "رشته تحصیلی")]
        public Nullable<int> EducationFieldId { get; set; }
        [Display(Name = "وضعیت تحصیلی")]
        public Nullable<int> EducationStatusId { get; set; }
        [Display(Name = "شرح تحصیلات")]
        public string EducationDesc { get; set; }
        [Display(Name = "ملیت")]
        public Nullable<int> NationalityId { get; set; }
        [Display(Name = "قومیت")]
        public Nullable<int> EthnicId { get; set; }
        [Display(Name = "مدت مهاجرت")]
        public Nullable<double> MigrateDuration { get; set; }
        [Display(Name = "استان محل تولد")]
        public Nullable<int> BirthProvinceId { get; set; }
        [Display(Name = "شهر محل تولد")]
        public Nullable<int> BirthCityId { get; set; }
        [Display(Name = "نحوه امرار معاش")]
        public string PersonLivelihood { get; set; }
        [Display(Name = "نوع شغل")]
        public Nullable<int> JobStatusId { get; set; }
        [Display(Name = " شغل")]
        public Nullable<int> JobId { get; set; }
        [Display(Name = " توضیحات تکمیلی درباره شغل")]
        public string JobDesc { get; set; }
        public Nullable<decimal> JobSalary { get; set; }
        [Display(Name = " علت ازدواج در کودکی")]
        public Nullable<int> ChildMarriageCauseId { get; set; }
        public bool PersonHasChildMarriage { get; set; }
        [Display(Name = "توضیحات تکمیلی درباره ازدواج کودک")]
        public string PersonChildMarriageDesc { get; set; }
        [Display(Name = "شماره پرونده")]
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> HealthTypeId { get; set; }
        public Nullable<int> DrugHistoryId { get; set; }
        public Nullable<int> DrugWithdrawalHistoryId { get; set; }
        public Nullable<int> DrugStatusId { get; set; }
        [Display(Name = "شماره پرونده")]
        public Nullable<int> BloodTypeId { get; set; }
        public Nullable<int> InsuranceTypeId { get; set; }
        public string InsuranceDesc { get; set; }
        [Display(Name = "هدف ورزشی")]
        public string SportTarget { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string PersonProfilePic { get; set; }

     
    }


    [MetadataType(typeof(PersonsMetaData))]
    public partial class Person
    {

    }
}
