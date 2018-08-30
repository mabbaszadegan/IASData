namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alley")]
    public partial class Alley
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alley()
        {
            Alley1 = new HashSet<Alley>();
            Family = new HashSet<Family>();
            House = new HashSet<House>();
        }

        public int AlleyId { get; set; }

        [Required]
        [StringLength(50)]
        public string AlleyName { get; set; }

        [StringLength(50)]
        public string AlleySummaryName { get; set; }

        [StringLength(100)]
        public string AlleyZiped { get; set; }

        public int StreetId { get; set; }

        public int? MainAlleyId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

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
