namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsCategory")]
    public partial class GoodsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsCategory()
        {
            GoodsType = new HashSet<GoodsType>();
        }

        public int GoodsCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string GoodsCategoryName { get; set; }

        [StringLength(50)]
        public string GoodsCategorySummaryName { get; set; }

        [StringLength(100)]
        public string GoodsCategoryZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsType> GoodsType { get; set; }
    }
}
