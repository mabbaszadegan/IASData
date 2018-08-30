namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDisableType")]
    public partial class PersonDisableType
    {
        public int PersonDisableTypeId { get; set; }

        public int PersonId { get; set; }

        public int DisableTypeId { get; set; }

        [StringLength(2000)]
        public string PersonDisableTypeDesc { get; set; }

        [StringLength(2000)]
        public string PersonDisableTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DisableType DisableType { get; set; }

        public virtual Person Person { get; set; }
    }
}
