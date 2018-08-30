namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ethnic")]
    public partial class Ethnic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ethnic()
        {
            DepartmentEthnic = new HashSet<DepartmentEthnic>();
            Person = new HashSet<Person>();
            SegmentEthnic = new HashSet<SegmentEthnic>();
            SegmentReconnaissanceEthnic = new HashSet<SegmentReconnaissanceEthnic>();
        }

        public int EthnicId { get; set; }

        [Required]
        [StringLength(50)]
        public string EthnicName { get; set; }

        [StringLength(50)]
        public string EthnicSummaryName { get; set; }

        [StringLength(100)]
        public string EthnicZiped { get; set; }

        public int NationalityId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEthnic> DepartmentEthnic { get; set; }

        public virtual Nationality Nationality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentEthnic> SegmentEthnic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegmentReconnaissanceEthnic> SegmentReconnaissanceEthnic { get; set; }
    }
}
