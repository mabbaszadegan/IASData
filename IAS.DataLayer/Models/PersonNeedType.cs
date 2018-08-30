namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonNeedType")]
    public partial class PersonNeedType
    {
        public int PersonNeedTypeId { get; set; }

        public int PersonId { get; set; }

        public int NeedTypeId { get; set; }

        public bool PersonNeedTypeIsFinancial { get; set; }

        [Required]
        [StringLength(2000)]
        public string PersonNeedTypeDesc { get; set; }

        [StringLength(4000)]
        public string PersonNeedTypeZiped { get; set; }

        [Column(TypeName = "money")]
        public decimal? PersonNeedTypeAmount { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual NeedType NeedType { get; set; }

        public virtual Person Person { get; set; }
    }
}
