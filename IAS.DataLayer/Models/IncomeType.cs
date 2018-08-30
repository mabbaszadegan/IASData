namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IncomeType")]
    public partial class IncomeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IncomeType()
        {
            PersonIncome = new HashSet<PersonIncome>();
        }

        public int IncomeTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string IncomeTypeName { get; set; }

        [StringLength(50)]
        public string IncomeTypeSummaryName { get; set; }

        [StringLength(4000)]
        public string IncomeTypeDesc { get; set; }

        [StringLength(4000)]
        public string IncomeTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonIncome> PersonIncome { get; set; }
    }
}
