namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonIncome")]
    public partial class PersonIncome
    {
        public int PersonIncomeId { get; set; }

        [Required]
        [StringLength(200)]
        public string IncomeName { get; set; }

        [StringLength(4000)]
        public string IncomeDesc { get; set; }

        [StringLength(4000)]
        public string IncomeZiped { get; set; }

        [Column(TypeName = "money")]
        public decimal MonthlyAmount { get; set; }

        public int IncomeTypeId { get; set; }

        public int PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual IncomeType IncomeType { get; set; }

        public virtual Person Person { get; set; }
    }
}
