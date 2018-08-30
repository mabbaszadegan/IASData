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
    
    public partial class RelationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RelationType()
        {
            this.DepartmentRelationType = new HashSet<DepartmentRelationType>();
            this.Family = new HashSet<Family>();
            this.FamilyMember = new HashSet<FamilyMember>();
            this.PersonChildAbuseType = new HashSet<PersonChildAbuseType>();
        }
    
        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; }
        public string RelationTypeSummaryName { get; set; }
        public string RelationTypeZiped { get; set; }
        public bool RelationTypeCanDuplicate { get; set; }
        public bool RelationTypeIsFather { get; set; }
        public bool RelationTypeIsMother { get; set; }
        public bool RelationTypeIsChild { get; set; }
        public Nullable<int> GenderId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
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
