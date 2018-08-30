namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personnel")]
    public partial class Personnel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personnel()
        {
            EducationYearClassCourse = new HashSet<EducationYearClassCourse>();
            EducationYearClassCourseHistory = new HashSet<EducationYearClassCourseHistory>();
            EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
            PersonnelActivityField = new HashSet<PersonnelActivityField>();
            PersonnelCourse = new HashSet<PersonnelCourse>();
            PersonnelFreeDay = new HashSet<PersonnelFreeDay>();
            PersonnelLog = new HashSet<PersonnelLog>();
            PersonnelPursuit = new HashSet<PersonnelPursuit>();
            PersonnelSkillType = new HashSet<PersonnelSkillType>();
            PersonnelWorkshop = new HashSet<PersonnelWorkshop>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int PersonnelId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonnelCode { get; set; }

        [Required]
        [StringLength(80)]
        public string PersonnelFirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string PersonnelLastName { get; set; }

        [StringLength(80)]
        public string PersonnelFatherName { get; set; }

        [StringLength(10)]
        public string PersonnelNationalCode { get; set; }

        [Required]
        [StringLength(80)]
        public string PersonnelZiped { get; set; }

        [StringLength(10)]
        public string PersonnelIdentityNo { get; set; }

        [StringLength(10)]
        public string PersonnelBirthDateSolar { get; set; }

        public DateTime? PersonnelBirthDate { get; set; }

        [StringLength(50)]
        public string PersonnelBirthPlace { get; set; }

        [StringLength(50)]
        public string PersonnelPhone { get; set; }

        [StringLength(50)]
        public string PersonnelCellPhone { get; set; }

        public int? PersonnelRank { get; set; }

        [StringLength(10)]
        public string PersonnelHireDateSolar { get; set; }

        public DateTime? PersonnelHireDate { get; set; }

        [StringLength(4000)]
        public string PersonnelDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string PersonnelAddress { get; set; }

        [Required]
        [StringLength(4000)]
        public string PersonnelAddressZiped { get; set; }

        [StringLength(50)]
        public string PersonnelCellPhone1 { get; set; }

        [StringLength(50)]
        public string PersonnelCellPhone2 { get; set; }

        [StringLength(50)]
        public string PersonnelHousePhone { get; set; }

        [StringLength(50)]
        public string PersonnelWorkPhone { get; set; }

        [StringLength(100)]
        public string PersonnelEmailAddress { get; set; }

        [StringLength(100)]
        public string PersonnelWebAdderess { get; set; }

        [StringLength(4000)]
        public string PersonnelActivityInSosapoverty { get; set; }

        [StringLength(4000)]
        public string PersonnelActivityInNGO { get; set; }

        [StringLength(4000)]
        public string PersonnelJobDesc { get; set; }

        [StringLength(4000)]
        public string PersonnelSkillDesc { get; set; }

        public bool PersonnelHasInternetAccess { get; set; }

        public bool PersonnelIsActive { get; set; }

        public bool PersonnelHasEquipment { get; set; }

        public int? PersonnelStatusId { get; set; }

        public int? ActivityTypeId { get; set; }

        public int? EquipmentTypeId { get; set; }

        public int DepartmentId { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? JobStatusId { get; set; }

        public int? JobId { get; set; }

        public int? EducationFieldId { get; set; }

        public int? EducationTypeId { get; set; }

        public int GenderId { get; set; }

        public int? TradingTypeId { get; set; }

        public int? NationalityId { get; set; }

        public int? CountryId { get; set; }

        public int? ProvinceId { get; set; }

        public int? CityId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

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
