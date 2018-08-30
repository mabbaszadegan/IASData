namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelationType")]
    public partial class RelationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RelationType()
        {
            DepartmentRelationType = new HashSet<DepartmentRelationType>();
            Family = new HashSet<Family>();
            FamilyMember = new HashSet<FamilyMember>();
            PersonChildAbuseType = new HashSet<PersonChildAbuseType>();
        }

        public int RelationTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string RelationTypeName { get; set; }

        [StringLength(50)]
        public string RelationTypeSummaryName { get; set; }

        [StringLength(100)]
        public string RelationTypeZiped { get; set; }

        public bool RelationTypeCanDuplicate { get; set; }

        public bool RelationTypeIsFather { get; set; }

        public bool RelationTypeIsMother { get; set; }

        public bool RelationTypeIsChild { get; set; }

        public int? GenderId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentRelationType> DepartmentRelationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMember { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonChildAbuseType> PersonChildAbuseType { get; set; }
    }
}
