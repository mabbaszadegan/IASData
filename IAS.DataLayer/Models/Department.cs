namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            DepartmentAppliance = new HashSet<DepartmentAppliance>();
            DepartmentBank = new HashSet<DepartmentBank>();
            DepartmentBelive = new HashSet<DepartmentBelive>();
            DepartmentChildAbuseType = new HashSet<DepartmentChildAbuseType>();
            DepartmentChildMarriageCause = new HashSet<DepartmentChildMarriageCause>();
            DepartmentCrimeType = new HashSet<DepartmentCrimeType>();
            DepartmentDiedCause = new HashSet<DepartmentDiedCause>();
            DepartmentDisableType = new HashSet<DepartmentDisableType>();
            DepartmentDrugType = new HashSet<DepartmentDrugType>();
            DepartmentEducationField = new HashSet<DepartmentEducationField>();
            DepartmentEducationType = new HashSet<DepartmentEducationType>();
            DepartmentEthnic = new HashSet<DepartmentEthnic>();
            DepartmentFuelType = new HashSet<DepartmentFuelType>();
            DepartmentHouseBuildingMaterial = new HashSet<DepartmentHouseBuildingMaterial>();
            DepartmentInsuranceType = new HashSet<DepartmentInsuranceType>();
            DepartmentJob = new HashSet<DepartmentJob>();
            DepartmentLeavingHouseCause = new HashSet<DepartmentLeavingHouseCause>();
            DepartmentNationality = new HashSet<DepartmentNationality>();
            DepartmentPowerSupply = new HashSet<DepartmentPowerSupply>();
            DepartmentReferrer = new HashSet<DepartmentReferrer>();
            DepartmentRelationType = new HashSet<DepartmentRelationType>();
            DepartmentReligion = new HashSet<DepartmentReligion>();
            DepartmentResidenceType = new HashSet<DepartmentResidenceType>();
            DepartmentSegment = new HashSet<DepartmentSegment>();
            DepartmentSkillType = new HashSet<DepartmentSkillType>();
            DepartmentSupportingOrgan = new HashSet<DepartmentSupportingOrgan>();
            DepartmentTeam = new HashSet<DepartmentTeam>();
            DepartmentWaterSource = new HashSet<DepartmentWaterSource>();
            EducationYear = new HashSet<EducationYear>();
            Person = new HashSet<Person>();
            Personnel = new HashSet<Personnel>();
            UserDepartment = new HashSet<UserDepartment>();
        }

        public int DepartmentId { get; set; }

        [Required]
        [StringLength(3)]
        public string DepartmentCode { get; set; }

        [Required]
        [StringLength(70)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(70)]
        public string DepartmentZiped { get; set; }

        [StringLength(400)]
        public string DepartmentAddress { get; set; }

        [StringLength(10)]
        public string DepartmentPostalCode { get; set; }

        [StringLength(20)]
        public string DepartmentPhone1 { get; set; }

        [StringLength(20)]
        public string DepartmentPhone2 { get; set; }

        [StringLength(20)]
        public string DepartmentPhone3 { get; set; }

        [StringLength(20)]
        public string DepartmentFax { get; set; }

        public int? DepartmentRank { get; set; }

        public bool DepartmentIsActive { get; set; }

        public short DepartmentTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DepartmentType DepartmentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentAppliance> DepartmentAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentBank> DepartmentBank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentBelive> DepartmentBelive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentChildAbuseType> DepartmentChildAbuseType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentChildMarriageCause> DepartmentChildMarriageCause { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentCrimeType> DepartmentCrimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentDiedCause> DepartmentDiedCause { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentDisableType> DepartmentDisableType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentDrugType> DepartmentDrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEducationField> DepartmentEducationField { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEducationType> DepartmentEducationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEthnic> DepartmentEthnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentFuelType> DepartmentFuelType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentHouseBuildingMaterial> DepartmentHouseBuildingMaterial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentInsuranceType> DepartmentInsuranceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentJob> DepartmentJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentLeavingHouseCause> DepartmentLeavingHouseCause { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentNationality> DepartmentNationality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentPowerSupply> DepartmentPowerSupply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentReferrer> DepartmentReferrer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentRelationType> DepartmentRelationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentReligion> DepartmentReligion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentResidenceType> DepartmentResidenceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSegment> DepartmentSegment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSkillType> DepartmentSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSupportingOrgan> DepartmentSupportingOrgan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeam> DepartmentTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentWaterSource> DepartmentWaterSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYear> EducationYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDepartment> UserDepartment { get; set; }
    }
}
