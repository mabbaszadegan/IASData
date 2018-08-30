namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            EducationYearClassMember = new HashSet<EducationYearClassMember>();
            Family = new HashSet<Family>();
            FamilyMember = new HashSet<FamilyMember>();
            PersonTalent = new HashSet<PersonTalent>();
            PersonChildAbuseType = new HashSet<PersonChildAbuseType>();
            PersonCrimeType = new HashSet<PersonCrimeType>();
            PersonDamage = new HashSet<PersonDamage>();
            PersonDentalMonitoring = new HashSet<PersonDentalMonitoring>();
            PersonDisableType = new HashSet<PersonDisableType>();
            PersonDrugType = new HashSet<PersonDrugType>();
            PersonExpense = new HashSet<PersonExpense>();
            PersonFacilityType = new HashSet<PersonFacilityType>();
            PersonIdentityDocument = new HashSet<PersonIdentityDocument>();
            PersonIncome = new HashSet<PersonIncome>();
            PersonInsuranceType = new HashSet<PersonInsuranceType>();
            PersonJob = new HashSet<PersonJob>();
            PersonLog = new HashSet<PersonLog>();
            PersonMedicalMonitoring = new HashSet<PersonMedicalMonitoring>();
            PersonNeedType = new HashSet<PersonNeedType>();
            PersonSicknessType = new HashSet<PersonSicknessType>();
            PersonSkillType = new HashSet<PersonSkillType>();
            PersonSupportingOrgan = new HashSet<PersonSupportingOrgan>();
            PersonTeam = new HashSet<PersonTeam>();
            PersonTraningCourseType = new HashSet<PersonTraningCourseType>();
            PersonWorkshop = new HashSet<PersonWorkshop>();
            RoleMemberAccess = new HashSet<RoleMemberAccess>();
        }

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

        public double? PersonBMIIndex { get; set; }

        [StringLength(4000)]
        public string PersonZiped { get; set; }

        public bool PersonHasPassport { get; set; }

        public bool PersonHasCard { get; set; }

        public bool PersonLeavedFamily { get; set; }

        [StringLength(10)]
        public string PersonLeavedFamilyDateSolar { get; set; }

        public DateTime? PersonLeavedFamilyDate { get; set; }

        public int? PersonLeavingHouseCauseId { get; set; }

        [StringLength(500)]
        public string PersonLeavingHouseCauseDesc { get; set; }

        [StringLength(500)]
        public string PersonLeavingHouseDesc { get; set; }

        [StringLength(2000)]
        public string PersonAddress { get; set; }

        [StringLength(2000)]
        public string PersonAddressZiped { get; set; }

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

        public int? EducationStatusId { get; set; }

        [StringLength(2000)]
        public string EducationDesc { get; set; }

        public int? NationalityId { get; set; }

        public int? EthnicId { get; set; }

        public double? MigrateDuration { get; set; }

        public int? BirthProvinceId { get; set; }

        public int? BirthCityId { get; set; }

        [StringLength(2000)]
        public string PersonLivelihood { get; set; }

        public int? JobStatusId { get; set; }

        public int? JobId { get; set; }

        [StringLength(4000)]
        public string JobDesc { get; set; }

        [Column(TypeName = "money")]
        public decimal? JobSalary { get; set; }

        public int? ChildMarriageCauseId { get; set; }

        public bool PersonHasChildMarriage { get; set; }

        [StringLength(2000)]
        public string PersonChildMarriageDesc { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? HealthTypeId { get; set; }

        public int? DrugHistoryId { get; set; }

        public int? DrugWithdrawalHistoryId { get; set; }

        public int? DrugStatusId { get; set; }

        public int? BloodTypeId { get; set; }

        public int? InsuranceTypeId { get; set; }

        [StringLength(4000)]
        public string InsuranceDesc { get; set; }

        [StringLength(4000)]
        public string SportTarget { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual Belive Belive { get; set; }

        public virtual BloodType BloodType { get; set; }

        public virtual ChildMarriageCause ChildMarriageCause { get; set; }

        public virtual City City { get; set; }

        public virtual Department Department { get; set; }

        public virtual DrugHistory DrugHistory { get; set; }

        public virtual DrugStatus DrugStatus { get; set; }

        public virtual DrugWithdrawalHistory DrugWithdrawalHistory { get; set; }

        public virtual EducationField EducationField { get; set; }

        public virtual EducationStatus EducationStatus { get; set; }

        public virtual EducationType EducationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMember> EducationYearClassMember { get; set; }

        public virtual Ethnic Ethnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMember { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual HealthType HealthType { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Job Job { get; set; }

        public virtual JobStatus JobStatus { get; set; }

        public virtual LeavingHouseCause LeavingHouseCause { get; set; }

        public virtual MaritalStatus MaritalStatus { get; set; }

        public virtual Nationality Nationality { get; set; }

        public virtual Person Person1 { get; set; }

        public virtual Person Person2 { get; set; }

        public virtual PersonStatus PersonStatus { get; set; }

        public virtual Province Province { get; set; }

        public virtual Religion Religion { get; set; }

        public virtual SupportingOrgan SupportingOrgan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTalent> PersonTalent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonChildAbuseType> PersonChildAbuseType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCrimeType> PersonCrimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDamage> PersonDamage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDentalMonitoring> PersonDentalMonitoring { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDisableType> PersonDisableType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDrugType> PersonDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonExpense> PersonExpense { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonFacilityType> PersonFacilityType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonIdentityDocument> PersonIdentityDocument { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonIncome> PersonIncome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonInsuranceType> PersonInsuranceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonJob> PersonJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonLog> PersonLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonMedicalMonitoring> PersonMedicalMonitoring { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonNeedType> PersonNeedType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSicknessType> PersonSicknessType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSkillType> PersonSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSupportingOrgan> PersonSupportingOrgan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeam> PersonTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTraningCourseType> PersonTraningCourseType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonWorkshop> PersonWorkshop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMemberAccess> RoleMemberAccess { get; set; }
    }
}
