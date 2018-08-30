namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Workshop")]
    public partial class Workshop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Workshop()
        {
            PersonnelWorkshop = new HashSet<PersonnelWorkshop>();
            PersonWorkshop = new HashSet<PersonWorkshop>();
            Workshop1 = new HashSet<Workshop>();
        }

        public int WorkshopId { get; set; }

        [Required]
        [StringLength(100)]
        public string WorkshopName { get; set; }

        [Required]
        [StringLength(4000)]
        public string WorkshopDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string WorkshopZiped { get; set; }

        public bool WorkshopForPersonnel { get; set; }

        public bool WorkshopForChild { get; set; }

        public bool WorkshopForMothers { get; set; }

        public bool WorkshopForBoys { get; set; }

        public bool WorkshopForGirls { get; set; }

        public bool WorkshopForFathers { get; set; }

        public int? WorkshopPrerequisiteId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelWorkshop> PersonnelWorkshop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonWorkshop> PersonWorkshop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workshop> Workshop1 { get; set; }

        public virtual Workshop Workshop2 { get; set; }
    }
}
