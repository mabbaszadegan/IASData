namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Nationality = new HashSet<Nationality>();
            Personnel = new HashSet<Personnel>();
            Province = new HashSet<Province>();
        }

        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        [StringLength(50)]
        public string CountrySummaryName { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryEngName { get; set; }

        [StringLength(50)]
        public string CountryEngSummaryName { get; set; }

        [StringLength(100)]
        public string CountryZiped { get; set; }

        public double? CountryLatitude { get; set; }

        public double? CountryLongitude { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nationality> Nationality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Province> Province { get; set; }
    }
}
