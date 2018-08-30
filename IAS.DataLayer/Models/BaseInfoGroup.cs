namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseInfoGroup")]
    public partial class BaseInfoGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseInfoGroup()
        {
            BaseInfo = new HashSet<BaseInfo>();
        }

        public int BaseInfoGroupId { get; set; }

        [Required]
        [StringLength(2)]
        public string BaseInfoGroupCode { get; set; }

        [Required]
        [StringLength(50)]
        public string BaseInfoGroupEnglishName { get; set; }

        [Required]
        [StringLength(50)]
        public string BaseInfoGroupPersianName { get; set; }

        [Required]
        [StringLength(500)]
        public string BaseInfoGroupZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseInfo> BaseInfo { get; set; }
    }
}
