namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DamageCause")]
    public partial class DamageCause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DamageCause()
        {
            PersonDamage = new HashSet<PersonDamage>();
        }

        public int DamageCauseId { get; set; }

        [Required]
        [StringLength(50)]
        public string DamageCauseName { get; set; }

        [StringLength(2000)]
        public string DamageCauseDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string DamageCauseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDamage> PersonDamage { get; set; }
    }
}
