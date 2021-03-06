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
    
    public partial class Alley
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alley()
        {
            this.Alley1 = new HashSet<Alley>();
            this.Family = new HashSet<Family>();
            this.House = new HashSet<House>();
        }
    
        public int AlleyId { get; set; }
        public string AlleyName { get; set; }
        public string AlleySummaryName { get; set; }
        public string AlleyZiped { get; set; }
        public int StreetId { get; set; }
        public Nullable<int> MainAlleyId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alley> Alley1 { get; set; }
        public virtual Alley Alley2 { get; set; }
        public virtual Street Street { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }
    }
}
