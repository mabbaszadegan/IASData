namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTeamCompetitionDetail")]
    public partial class DepartmentTeamCompetitionDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTeamCompetitionDetail()
        {
            PersonTeamGrade = new HashSet<PersonTeamGrade>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentTeamCompetitionDetailId { get; set; }

        public int DepartmentTeamCompetitionId { get; set; }

        [Required]
        [StringLength(16)]
        public string CompetitionTimeSolar { get; set; }

        public DateTime CompetitionTime { get; set; }

        [Required]
        [StringLength(16)]
        public string ExerciseFinishTimeSolar { get; set; }

        public DateTime ExerciseFinishTime { get; set; }

        [StringLength(500)]
        public string Place { get; set; }

        [StringLength(2000)]
        public string CompetitionDesc { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamCompetitionDetailZiped { get; set; }

        public int? OpponentTeamId { get; set; }

        public int CompetitionResultId { get; set; }

        [StringLength(2000)]
        public string CompetitionResultDesc { get; set; }

        public int? DepartmentTeamPoints { get; set; }

        public int? OpponentTeamPoints { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DepartmentTeam DepartmentTeam { get; set; }

        public virtual DepartmentTeamCompetition DepartmentTeamCompetition { get; set; }

        public virtual Grade Grade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade { get; set; }
    }
}
