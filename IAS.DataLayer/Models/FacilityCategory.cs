namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacilityCategory")]
    public partial class FacilityCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacilityCategory()
        {
            FacilityType = new HashSet<FacilityType>();
        }

        public int FacilityCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string FacilityCategoryName { get; set; }

        [StringLength(50)]
        public string FacilityCategorySummaryName { get; set; }

        [StringLength(100)]
        public string FacilityCategoryZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime ChangeTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacilityType> FacilityType { get; set; }
    }
}
