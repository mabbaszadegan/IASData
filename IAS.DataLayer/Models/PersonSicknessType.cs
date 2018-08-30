namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSicknessType")]
    public partial class PersonSicknessType
    {
        public int PersonSicknessTypeId { get; set; }

        public int PersonId { get; set; }

        public int SicknessTypeId { get; set; }

        [StringLength(2000)]
        public string SicknessName { get; set; }

        [StringLength(2000)]
        public string SicknessEnglishName { get; set; }

        [StringLength(2000)]
        public string PersonSicknessDesc { get; set; }

        [StringLength(2000)]
        public string PersonSicknessZiped { get; set; }

        [Column(TypeName = "money")]
        public decimal? SicknessExpense { get; set; }

        public DateTime? SicknessStartDate { get; set; }

        [StringLength(10)]
        public string SicknessStartDateSolar { get; set; }

        public DateTime? SicknessFinishDate { get; set; }

        [StringLength(10)]
        public string SicknessFinishDateSolar { get; set; }

        public int TreatmentStatusId { get; set; }

        public bool PersonUseSpecialDrug { get; set; }

        [StringLength(500)]
        public string DrugDesc { get; set; }

        [StringLength(2000)]
        public string MedicalAdvice { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual SicknessType SicknessType { get; set; }

        public virtual TreatmentStatus TreatmentStatus { get; set; }
    }
}
