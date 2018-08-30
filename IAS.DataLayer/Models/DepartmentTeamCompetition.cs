namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTeamCompetition")]
    public partial class DepartmentTeamCompetition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTeamCompetition()
        {
            DepartmentTeamCompetitionDetail = new HashSet<DepartmentTeamCompetitionDetail>();
            PersonTeamGrade = new HashSet<PersonTeamGrade>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentTeamCompetitionId { get; set; }

        public int CompetitionId { get; set; }

        public int DepartmentTeamId { get; set; }

        [StringLength(500)]
        public string Place { get; set; }

        [StringLength(2000)]
        public string CompetitionDesc { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamCompetitionZiped { get; set; }

        public int? GradeId { get; set; }

        [StringLength(2000)]
        public string CompetitionResultDesc { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual DepartmentTeam DepartmentTeam { get; set; }

        public virtual Grade Grade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetitionDetail> DepartmentTeamCompetitionDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade { get; set; }
    }
}
