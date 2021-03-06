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
    
    public partial class ReconnaissanceCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReconnaissanceCause()
        {
            this.FamilyReconnaissance = new HashSet<FamilyReconnaissance>();
            this.SegmentReconnaissance = new HashSet<SegmentReconnaissance>();
        }
    
        public int ReconnaissanceCauseId { get; set; }
        public string ReconnaissanceCauseName { get; set; }
        public string ReconnaissanceCauseDesc { get; set; }
        public string ReconnaissanceCauseZiped { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyReconnaissance> FamilyReconnaissance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissance> SegmentReconnaissance { get; set; }
    }
}
