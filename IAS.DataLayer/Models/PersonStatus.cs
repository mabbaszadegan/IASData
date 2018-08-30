namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PersonStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonStatus()
        {
            Person = new HashSet<Person>();
        }

        public int PersonStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonStatusName { get; set; }

        [StringLength(50)]
        public string PersonStatusSummaryName { get; set; }

        [StringLength(100)]
        public string PersonStatusZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
