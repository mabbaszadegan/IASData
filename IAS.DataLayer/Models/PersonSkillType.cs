namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSkillType")]
    public partial class PersonSkillType
    {
        public int PersonSkillTypeId { get; set; }

        public int PersonId { get; set; }

        public int SkillTypeId { get; set; }

        public int SkillTypeLevelId { get; set; }

        [StringLength(2000)]
        public string SkillTypeName { get; set; }

        [StringLength(2000)]
        public string PersonSkillTypeDesc { get; set; }

        [StringLength(4000)]
        public string PersonSkillTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual SkillType SkillType { get; set; }

        public virtual SkillTypeLevel SkillTypeLevel { get; set; }
    }
}
