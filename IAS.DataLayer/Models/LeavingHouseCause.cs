namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LeavingHouseCause")]
    public partial class LeavingHouseCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LeavingHouseCause()
        {
            DepartmentLeavingHouseCause = new HashSet<DepartmentLeavingHouseCause>();
            Family = new HashSet<Family>();
            Family1 = new HashSet<Family>();
            HouseFamily = new HashSet<HouseFamily>();
            Person = new HashSet<Person>();
        }

        public int LeavingHouseCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string LeavingHouseCauseName { get; set; }

        [StringLength(2000)]
        public string LeavingHouseCauseDesc { get; set; }

        [StringLength(2000)]
        public string LeavingHouseCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentLeavingHouseCause> DepartmentLeavingHouseCause { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family> Family1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseFamily> HouseFamily { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }
    }
}
