namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public partial class Region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Region()
        {
            Segment = new HashSet<Segment>();
        }

        public int RegionId { get; set; }

        [Required]
        [StringLength(200)]
        public string RegionName { get; set; }

        [StringLength(200)]
        public string RegionSummaryName { get; set; }

        [StringLength(4000)]
        public string RegionZiped { get; set; }

        public int CityId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Segment> Segment { get; set; }
    }
}
