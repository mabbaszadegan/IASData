namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExpenseType")]
    public partial class ExpenseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseType()
        {
            PersonExpense = new HashSet<PersonExpense>();
        }

        public int ExpenseTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpenseTypeName { get; set; }

        [StringLength(50)]
        public string ExpenseTypeSummaryName { get; set; }

        [StringLength(4000)]
        public string ExpenseTypeDesc { get; set; }

        [StringLength(4000)]
        public string ExpenseTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonExpense> PersonExpense { get; set; }
    }
}
