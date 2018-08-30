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
    
    public partial class Personnel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personnel()
        {
            this.EducationYearClassCourse = new HashSet<EducationYearClassCourse>();
            this.EducationYearClassCourseHistory = new HashSet<EducationYearClassCourseHistory>();
            this.EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
            this.PersonnelActivityField = new HashSet<PersonnelActivityField>();
            this.PersonnelCourse = new HashSet<PersonnelCourse>();
            this.PersonnelFreeDay = new HashSet<PersonnelFreeDay>();
            this.PersonnelLog = new HashSet<PersonnelLog>();
            this.PersonnelPursuit = new HashSet<PersonnelPursuit>();
            this.PersonnelSkillType = new HashSet<PersonnelSkillType>();
            this.PersonnelWorkshop = new HashSet<PersonnelWorkshop>();
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int PersonnelId { get; set; }
        public string PersonnelCode { get; set; }
        public string PersonnelFirstName { get; set; }
        public string PersonnelLastName { get; set; }
        public string PersonnelFatherName { get; set; }
        public string PersonnelNationalCode { get; set; }
        public string PersonnelZiped { get; set; }
        public string PersonnelIdentityNo { get; set; }
        public string PersonnelBirthDateSolar { get; set; }
        public Nullable<System.DateTime> PersonnelBirthDate { get; set; }
        public string PersonnelBirthPlace { get; set; }
        public string PersonnelPhone { get; set; }
        public string PersonnelCellPhone { get; set; }
        public Nullable<int> PersonnelRank { get; set; }
        public string PersonnelHireDateSolar { get; set; }
        public Nullable<System.DateTime> PersonnelHireDate { get; set; }
        public string PersonnelDesc { get; set; }
        public string PersonnelAddress { get; set; }
        public string PersonnelAddressZiped { get; set; }
        public string PersonnelCellPhone1 { get; set; }
        public string PersonnelCellPhone2 { get; set; }
        public string PersonnelHousePhone { get; set; }
        public string PersonnelWorkPhone { get; set; }
        public string PersonnelEmailAddress { get; set; }
        public string PersonnelWebAdderess { get; set; }
        public string PersonnelActivityInSosapoverty { get; set; }
        public string PersonnelActivityInNGO { get; set; }
        public string PersonnelJobDesc { get; set; }
        public string PersonnelSkillDesc { get; set; }
        public bool PersonnelHasInternetAccess { get; set; }
        public bool PersonnelIsActive { get; set; }
        public bool PersonnelHasEquipment { get; set; }
        public Nullable<int> PersonnelStatusId { get; set; }
        public Nullable<int> ActivityTypeId { get; set; }
        public Nullable<int> EquipmentTypeId { get; set; }
        public int DepartmentId { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> JobStatusId { get; set; }
        public Nullable<int> JobId { get; set; }
        public Nullable<int> EducationFieldId { get; set; }
        public Nullable<int> EducationTypeId { get; set; }
        public int GenderId { get; set; }
        public Nullable<int> TradingTypeId { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> CityId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual ActivityType ActivityType { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual EducationField EducationField { get; set; }
        public virtual EducationType EducationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourse> EducationYearClassCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassCourseHistory> EducationYearClassCourseHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Job Job { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual PersonnelStatus PersonnelStatus { get; set; }
        public virtual Province Province { get; set; }
        public virtual TradingType TradingType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelActivityField> PersonnelActivityField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelCourse> PersonnelCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelFreeDay> PersonnelFreeDay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelLog> PersonnelLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelPursuit> PersonnelPursuit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelSkillType> PersonnelSkillType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelWorkshop> PersonnelWorkshop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
