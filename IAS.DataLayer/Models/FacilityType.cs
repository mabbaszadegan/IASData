namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacilityType")]
    public partial class FacilityType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacilityType()
        {
            PersonFacilityType = new HashSet<PersonFacilityType>();
        }

        public int FacilityTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FacilityTypeName { get; set; }

        [StringLength(50)]
        public string FacilityTypeSummaryName { get; set; }

        [StringLength(100)]
        public string FacilityTypeZiped { get; set; }

        public bool? FacilityTypeIsCash { get; set; }

        public int? FacilityCategoryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime ChangeTime { get; set; }

        public virtual FacilityCategory FacilityCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonFacilityType> PersonFacilityType { get; set; }
    }
}
