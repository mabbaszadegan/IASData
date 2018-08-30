namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompetitionSkillTypeAgeRange")]
    public partial class CompetitionSkillTypeAgeRange
    {
        public int CompetitionSkillTypeAgeRangeId { get; set; }

        public int SkillTypeAgeRangeId { get; set; }

        public int CompetitionId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual SkillTypeAgeRange SkillTypeAgeRange { get; set; }
    }
}
