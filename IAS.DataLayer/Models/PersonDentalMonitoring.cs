namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDentalMonitoring")]
    public partial class PersonDentalMonitoring
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonDentalMonitoring()
        {
            PersonToothStatus = new HashSet<PersonToothStatus>();
        }

        public int PersonDentalMonitoringId { get; set; }

        public DateTime PersonDentalMonitoringDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonDentalMonitoringDateSolar { get; set; }

        public int PersonId { get; set; }

        public int ToothCount { get; set; }

        public int NormalToothCount { get; set; }

        public int BrokenToothCount { get; set; }

        public int MilkToothCount { get; set; }

        public int PermanentToothCount { get; set; }

        [StringLength(4000)]
        public string PersonDentalMonitoringDesc { get; set; }

        [StringLength(4000)]
        public string PersonDentalMonitoringZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonToothStatus> PersonToothStatus { get; set; }
    }
}
