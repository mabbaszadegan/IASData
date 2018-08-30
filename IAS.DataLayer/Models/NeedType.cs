namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NeedType")]
    public partial class NeedType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NeedType()
        {
            PersonNeedType = new HashSet<PersonNeedType>();
        }

        public int NeedTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string NeedTypeName { get; set; }

        [StringLength(50)]
        public string NeedTypeSummaryName { get; set; }

        [StringLength(100)]
        public string NeedTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonNeedType> PersonNeedType { get; set; }
    }
}
