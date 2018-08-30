namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods()
        {
            DepartmentTeamGoods = new HashSet<DepartmentTeamGoods>();
            TeamRequiredGoods = new HashSet<TeamRequiredGoods>();
        }

        public int GoodsId { get; set; }

        [Required]
        [StringLength(50)]
        public string GoodsName { get; set; }

        [StringLength(50)]
        public string GoodsSummaryName { get; set; }

        [StringLength(100)]
        public string GoodsZiped { get; set; }

        public int GoodsTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamGoods> DepartmentTeamGoods { get; set; }

        public virtual GoodsType GoodsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamRequiredGoods> TeamRequiredGoods { get; set; }
    }
}
