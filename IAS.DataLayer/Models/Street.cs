namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Street")]
    public partial class Street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Street()
        {
            Alley = new HashSet<Alley>();
            Family = new HashSet<Family>();
            House = new HashSet<House>();
            Street1 = new HashSet<Street>();
        }

        public int StreetId { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }

        [StringLength(50)]
        public string StreetSummaryName { get; set; }

        [StringLength(100)]
        public string StreetZiped { get; set; }

        public int SegmentId { get; set; }

        public int? MainStreetId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alley> Alley { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House> House { get; set; }

        public virtual Segment Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Street> Street1 { get; set; }

        public virtual Street Street2 { get; set; }
    }
}
