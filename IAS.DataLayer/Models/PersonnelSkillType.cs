namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelSkillType")]
    public partial class PersonnelSkillType
    {
        public int PersonnelSkillTypeId { get; set; }

        public int PersonnelId { get; set; }

        public int SkillTypeId { get; set; }

        public int SkillTypeLevelId { get; set; }

        [StringLength(50)]
        public string BeltColor { get; set; }

        public int? ShirtNo { get; set; }

        public int? Duration { get; set; }

        [StringLength(500)]
        public string PersonnelSkillTypeDesc { get; set; }

        [StringLength(500)]
        public string PersonnelSkillTypeExpertise { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual SkillType SkillType { get; set; }

        public virtual SkillTypeLevel SkillTypeLevel { get; set; }
    }
}
