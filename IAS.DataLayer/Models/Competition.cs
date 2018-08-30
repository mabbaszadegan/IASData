namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Competition")]
    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            CompetitionSkillTypeAgeRange = new HashSet<CompetitionSkillTypeAgeRange>();
            DepartmentTeamCompetition = new HashSet<DepartmentTeamCompetition>();
        }

        public int CompetitionId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompetitionName { get; set; }

        [StringLength(50)]
        public string CompetitionSummaryName { get; set; }

        [StringLength(100)]
        public string CompetitionZiped { get; set; }

        [Required]
        [StringLength(10)]
        public string CompetitionStartDateSolar { get; set; }

        public DateTime CompetitionStartDate { get; set; }

        public int CompetitionDuration { get; set; }

        public int CompetitionTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual CompetitionType CompetitionType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetitionSkillTypeAgeRange> CompetitionSkillTypeAgeRange { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetition> DepartmentTeamCompetition { get; set; }
    }
}
