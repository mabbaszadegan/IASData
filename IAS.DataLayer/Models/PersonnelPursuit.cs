namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelPursuit")]
    public partial class PersonnelPursuit
    {
        public int PersonnelPursuitId { get; set; }

        [Required]
        [StringLength(16)]
        public string PersonnelPursuitTimeSolar { get; set; }

        public DateTime PersonnelPursuitTime { get; set; }

        [StringLength(3000)]
        public string PersonnelPursuitDesc { get; set; }

        [StringLength(3000)]
        public string PersonnelPursuitZiped { get; set; }

        public int PersonnelPursuitResultId { get; set; }

        public int PersonnelId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual PersonnelPursuitResult PersonnelPursuitResult { get; set; }
    }
}
