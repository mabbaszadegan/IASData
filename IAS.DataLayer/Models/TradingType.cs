namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TradingType")]
    public partial class TradingType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TradingType()
        {
            Personnel = new HashSet<Personnel>();
        }

        public int TradingTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string TradingTypeName { get; set; }

        [StringLength(50)]
        public string TradingTypeSummaryName { get; set; }

        [StringLength(100)]
        public string TradingTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
