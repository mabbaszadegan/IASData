namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrugHistory")]
    public partial class DrugHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugHistory()
        {
            Person = new HashSet<Person>();
        }

        public int DrugHistoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugHistoryName { get; set; }

        [StringLength(50)]
        public string DrugHistorySummaryName { get; set; }

        [StringLength(100)]
        public string DrugHistoryZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
