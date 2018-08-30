namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChildMarriageCause")]
    public partial class ChildMarriageCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChildMarriageCause()
        {
            DepartmentChildMarriageCause = new HashSet<DepartmentChildMarriageCause>();
            Person = new HashSet<Person>();
        }

        public int ChildMarriageCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildMarriageCauseName { get; set; }

        [StringLength(50)]
        public string ChildMarriageCauseSummaryName { get; set; }

        [StringLength(100)]
        public string ChildMarriageCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentChildMarriageCause> DepartmentChildMarriageCause { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
