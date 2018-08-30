namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyReconnaissance")]
    public partial class FamilyReconnaissance
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FamilyReconnaissanceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FamilyId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string FamilyReconnaissanceDateSolar { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FamilyReconnaissanceDate { get; set; }

        [StringLength(4000)]
        public string FamilyReconnaissanceDesc { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4000)]
        public string FamilyReconnaissanceZiped { get; set; }

        public int? ReconnaissanceCauseId { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InsertUserId { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Family Family { get; set; }

        public virtual ReconnaissanceCause ReconnaissanceCause { get; set; }
    }
}
