namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTeam")]
    public partial class DepartmentTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTeam()
        {
            DepartmentTeamCompetition = new HashSet<DepartmentTeamCompetition>();
            DepartmentTeamCompetitionDetail = new HashSet<DepartmentTeamCompetitionDetail>();
            DepartmentTeamExerciseHistory = new HashSet<DepartmentTeamExerciseHistory>();
            DepartmentTeamExerciseTime = new HashSet<DepartmentTeamExerciseTime>();
            DepartmentTeamGoods = new HashSet<DepartmentTeamGoods>();
            PersonTeam = new HashSet<PersonTeam>();
        }

        public int DepartmentTeamId { get; set; }

        public int DepartmentId { get; set; }

        public int TeamId { get; set; }

        public DateTime? DepartmentTeamStartDate { get; set; }

        [StringLength(10)]
        public string DepartmentTeamStartDateSolar1 { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamDesc { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual Team Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetition> DepartmentTeamCompetition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamCompetitionDetail> DepartmentTeamCompetitionDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamExerciseHistory> DepartmentTeamExerciseHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamExerciseTime> DepartmentTeamExerciseTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamGoods> DepartmentTeamGoods { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeam> PersonTeam { get; set; }
    }
}
