namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Team")]
    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            DepartmentTeam = new HashSet<DepartmentTeam>();
            TeamRequiredGoods = new HashSet<TeamRequiredGoods>();
        }

        public int TeamId { get; set; }

        public int SkillTypeId { get; set; }

        public int? SkillTypeAgeRangeId { get; set; }

        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        [StringLength(50)]
        public string TeamSummaryName { get; set; }

        [StringLength(100)]
        public string TeamZiped { get; set; }

        public int? GenderId { get; set; }

        public int? SkillTypeMethod { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeam> DepartmentTeam { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual SkillType SkillType { get; set; }

        public virtual SkillType SkillType1 { get; set; }

        public virtual SkillTypeAgeRange SkillTypeAgeRange { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamRequiredGoods> TeamRequiredGoods { get; set; }
    }
}
