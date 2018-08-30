namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsType")]
    public partial class GoodsType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsType()
        {
            Goods = new HashSet<Goods>();
        }

        public int GoodsTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string GoodsTypeName { get; set; }

        [StringLength(50)]
        public string GoodsTypeSummaryName { get; set; }

        [StringLength(100)]
        public string GoodsTypeZiped { get; set; }

        public int GoodsCategoryId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods> Goods { get; set; }

        public virtual GoodsCategory GoodsCategory { get; set; }
    }
}
