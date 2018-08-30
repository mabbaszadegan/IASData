namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillType")]
    public partial class SkillType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillType()
        {
            BeltColor = new HashSet<BeltColor>();
            DepartmentSkillType = new HashSet<DepartmentSkillType>();
            Expertise = new HashSet<Expertise>();
            Grade = new HashSet<Grade>();
            PersonnelSkillType = new HashSet<PersonnelSkillType>();
            PersonSkillType = new HashSet<PersonSkillType>();
            SkillType1 = new HashSet<SkillType>();
            SkillTypeAgeRange = new HashSet<SkillTypeAgeRange>();
            Team = new HashSet<Team>();
            Team1 = new HashSet<Team>();
        }

        public int SkillTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillTypeName { get; set; }

        [StringLength(50)]
        public string SkillTypeSummaryName { get; set; }

        [StringLength(100)]
        public string SkillTypeZiped { get; set; }

        public int? ParentSkillTypeId { get; set; }

        public bool SkillTypeIsSolitary { get; set; }

        public bool SkillTypeHasBeltColor { get; set; }

        public bool SkillTypeHasShirtNo { get; set; }

        public bool SkillTypeHasExpertise { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BeltColor> BeltColor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentSkillType> DepartmentSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expertise> Expertise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelSkillType> PersonnelSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSkillType> PersonSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillType> SkillType1 { get; set; }

        public virtual SkillType SkillType2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillTypeAgeRange> SkillTypeAgeRange { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Team1 { get; set; }
    }
}
