namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonExpense")]
    public partial class PersonExpense
    {
        public int PersonExpenseId { get; set; }

        [Required]
        [StringLength(200)]
        public string ExpenseName { get; set; }

        [StringLength(4000)]
        public string ExpenseDesc { get; set; }

        [StringLength(4000)]
        public string ExpenseZiped { get; set; }

        [Column(TypeName = "money")]
        public decimal MonthlyAmount { get; set; }

        public int ExpenseTypeId { get; set; }

        public int PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual ExpenseType ExpenseType { get; set; }

        public virtual Person Person { get; set; }
    }
}
