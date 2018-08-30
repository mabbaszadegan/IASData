namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillTypeAgeRange")]
    public partial class SkillTypeAgeRange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillTypeAgeRange()
        {
            CompetitionSkillTypeAgeRange = new HashSet<CompetitionSkillTypeAgeRange>();
            Team = new HashSet<Team>();
        }

        public int SkillTypeAgeRangeId { get; set; }

        public int SkillTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillTypeAgeRangeName { get; set; }

        public int? AgeRangeMin { get; set; }

        public int? AgeRangeMax { get; set; }

        [StringLength(100)]
        public string SkillTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetitionSkillTypeAgeRange> CompetitionSkillTypeAgeRange { get; set; }

        public virtual SkillType SkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Team { get; set; }
    }
}
