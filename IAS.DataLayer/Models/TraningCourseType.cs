namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraningCourseType")]
    public partial class TraningCourseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TraningCourseType()
        {
            PersonTraningCourseType = new HashSet<PersonTraningCourseType>();
        }

        public int TraningCourseTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string TraningCourseTypeName { get; set; }

        [StringLength(50)]
        public string TraningCourseTypeSummaryName { get; set; }

        [StringLength(100)]
        public string TraningCourseTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTraningCourseType> PersonTraningCourseType { get; set; }
    }
}
