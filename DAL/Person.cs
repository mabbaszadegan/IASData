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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.DepartmentTeamCompetitionMember = new HashSet<DepartmentTeamCompetitionMember>();
            this.EducationYearClassMember = new HashSet<EducationYearClassMember>();
            this.Family = new HashSet<Family>();
            this.FamilyMember = new HashSet<FamilyMember>();
            this.FamilyPhone = new HashSet<FamilyPhone>();
            this.PersonTalent = new HashSet<PersonTalent>();
            this.PersonChildAbuseType = new HashSet<PersonChildAbuseType>();
            this.PersonCrimeType = new HashSet<PersonCrimeType>();
            this.PersonDamage = new HashSet<PersonDamage>();
            this.PersonDentalMonitoring = new HashSet<PersonDentalMonitoring>();
            this.PersonDisableType = new HashSet<PersonDisableType>();
            this.PersonDrugType = new HashSet<PersonDrugType>();
            this.PersonExpense = new HashSet<PersonExpense>();
            this.PersonFacilityType = new HashSet<PersonFacilityType>();
            this.PersonIdentityDocument = new HashSet<PersonIdentityDocument>();
            this.PersonIncome = new HashSet<PersonIncome>();
            this.PersonInsuranceType = new HashSet<PersonInsuranceType>();
            this.PersonJob = new HashSet<PersonJob>();
            this.PersonLog = new HashSet<PersonLog>();
            this.PersonMedicalMonitoring = new HashSet<PersonMedicalMonitoring>();
            this.PersonNeedType = new HashSet<PersonNeedType>();
            this.PersonSicknessType = new HashSet<PersonSicknessType>();
            this.PersonSkillType = new HashSet<PersonSkillType>();
            this.PersonSupportingOrgan = new HashSet<PersonSupportingOrgan>();
            this.PersonTeam = new HashSet<PersonTeam>();
            this.PersonTraningCourseType = new HashSet<PersonTraningCourseType>();
            this.PersonWorkshop = new HashSet<PersonWorkshop>();
            this.RoleMemberAccess = new HashSet<RoleMemberAccess>();
        }
    
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
        public string PersonProfilePic { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    
        public virtual Bank Bank { get; set; }
        public virtual Bank Bank1 { get; set; }
        public virtual Belive Belive { get; set; }
        public virtual Belive Belive1 { get; set; }
        public virtual BloodType BloodType { get; set; }
        public virtual BloodType BloodType1 { get; set; }
        public virtual ChildMarriageCause ChildMarriageCause { get; set; }
        public virtual ChildMarriageCause ChildMarriageCause1 { get; set; }
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Department Department { get; set; }
        public virtual Department Department1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetitionMember> DepartmentTeamCompetitionMember { get; set; }
        public virtual DrugHistory DrugHistory { get; set; }
        public virtual DrugHistory DrugHistory1 { get; set; }
        public virtual DrugStatus DrugStatus { get; set; }
        public virtual DrugStatus DrugStatus1 { get; set; }
        public virtual DrugWithdrawalHistory DrugWithdrawalHistory { get; set; }
        public virtual DrugWithdrawalHistory DrugWithdrawalHistory1 { get; set; }
        public virtual EducationField EducationField { get; set; }
        public virtual EducationField EducationField1 { get; set; }
        public virtual EducationStatus EducationStatus { get; set; }
        public virtual EducationStatus EducationStatus1 { get; set; }
        public virtual EducationType EducationType { get; set; }
        public virtual EducationType EducationType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMember> EducationYearClassMember { get; set; }
        public virtual Ethnic Ethnic { get; set; }
        public virtual Ethnic Ethnic1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyPhone> FamilyPhone { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Gender Gender1 { get; set; }
        public virtual HealthType HealthType { get; set; }
        public virtual HealthType HealthType1 { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
        public virtual InsuranceType InsuranceType1 { get; set; }
        public virtual Job Job { get; set; }
        public virtual Job Job1 { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public virtual JobStatus JobStatus1 { get; set; }
        public virtual LeavingHouseCause LeavingHouseCause { get; set; }
        public virtual LeavingHouseCause LeavingHouseCause1 { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual MaritalStatus MaritalStatus1 { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Nationality Nationality1 { get; set; }
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
        public virtual Person Person11 { get; set; }
        public virtual Person Person3 { get; set; }
        public virtual PersonStatus PersonStatus1 { get; set; }
        public virtual Province Province1 { get; set; }
        public virtual Religion Religion1 { get; set; }
        public virtual SupportingOrgan SupportingOrgan1 { get; set; }
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
