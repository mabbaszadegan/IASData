namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Province")]
    public partial class Province
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Province()
        {
            City = new HashSet<City>();
            Person = new HashSet<Person>();
            Personnel = new HashSet<Personnel>();
        }

        public int ProvinceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProvinceName { get; set; }

        [StringLength(50)]
        public string ProvinceSummaryName { get; set; }

        [StringLength(100)]
        public string ProvinceZiped { get; set; }

        public double? ProvinceLatitude { get; set; }

        public double? ProvinceLongitude { get; set; }

        public int CountryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> City { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
