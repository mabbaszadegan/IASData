namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appliance")]
    public partial class Appliance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appliance()
        {
            DepartmentAppliance = new HashSet<DepartmentAppliance>();
            FamilyAppliance = new HashSet<FamilyAppliance>();
            HouseAppliance = new HashSet<HouseAppliance>();
        }

        public int ApplianceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplianceName { get; set; }

        [StringLength(50)]
        public string ApplianceSummaryName { get; set; }

        [StringLength(100)]
        public string ApplianceZiped { get; set; }

        public bool HouseRelated { get; set; }

        public bool FamilyRelated { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentAppliance> DepartmentAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyAppliance> FamilyAppliance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseAppliance> HouseAppliance { get; set; }
    }
}
