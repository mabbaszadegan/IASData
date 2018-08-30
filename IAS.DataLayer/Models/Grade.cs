namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grade")]
    public partial class Grade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grade()
        {
            DepartmentTeamCompetition = new HashSet<DepartmentTeamCompetition>();
            DepartmentTeamCompetitionDetail = new HashSet<DepartmentTeamCompetitionDetail>();
        }

        public int GradeId { get; set; }

        public int SkillTypeId { get; set; }

        public int? GradePoints { get; set; }

        [Required]
        [StringLength(50)]
        public string GradeName { get; set; }

        [StringLength(100)]
        public string GradeZiped { get; set; }

        public bool PersonRelated { get; set; }

        public bool TeamRelated { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetition> DepartmentTeamCompetition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetitionDetail> DepartmentTeamCompetitionDetail { get; set; }

        public virtual SkillType SkillType { get; set; }
    }
}
