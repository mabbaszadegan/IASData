namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelPursuitResult")]
    public partial class PersonnelPursuitResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonnelPursuitResult()
        {
            PersonnelPursuit = new HashSet<PersonnelPursuit>();
        }

        public int PersonnelPursuitResultId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonnelPursuitResultName { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonnelPursuitResultZiped { get; set; }

        public int PersonnelStatusId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelPursuit> PersonnelPursuit { get; set; }

        public virtual PersonnelStatus PersonnelStatus { get; set; }
    }
}
