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
    
    public partial class DamageCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DamageCause()
        {
            this.PersonDamage = new HashSet<PersonDamage>();
        }
    
        public int DamageCauseId { get; set; }
        public string DamageCauseName { get; set; }
        public string DamageCauseDesc { get; set; }
        public string DamageCauseZiped { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDamage> PersonDamage { get; set; }
    }
}
