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
    
    public partial class Ethnic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ethnic()
        {
            this.DepartmentEthnic = new HashSet<DepartmentEthnic>();
            this.Person = new HashSet<Person>();
            this.Person1 = new HashSet<Person>();
            this.SegmentEthnic = new HashSet<SegmentEthnic>();
            this.SegmentReconnaissanceEthnic = new HashSet<SegmentReconnaissanceEthnic>();
        }
    
        public int EthnicId { get; set; }
        public string EthnicName { get; set; }
        public string EthnicSummaryName { get; set; }
        public string EthnicZiped { get; set; }
        public int NationalityId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEthnic> DepartmentEthnic { get; set; }
        public virtual Nationality Nationality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentEthnic> SegmentEthnic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceEthnic> SegmentReconnaissanceEthnic { get; set; }
    }
}
