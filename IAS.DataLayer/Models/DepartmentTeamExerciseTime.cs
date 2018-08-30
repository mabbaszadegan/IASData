namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTeamExerciseTime")]
    public partial class DepartmentTeamExerciseTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentTeamExerciseTime()
        {
            DepartmentTeamExerciseHistory = new HashSet<DepartmentTeamExerciseHistory>();
        }

        public int DepartmentTeamExerciseTimeId { get; set; }

        public int DepartmentTeamId { get; set; }

        public int WeekDayId { get; set; }

        [Required]
        [StringLength(5)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(5)]
        public string FinishTime { get; set; }

        [StringLength(500)]
        public string Place { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamExerciseTimeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DepartmentTeam DepartmentTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamExerciseHistory> DepartmentTeamExerciseHistory { get; set; }

        public virtual WeekDay WeekDay { get; set; }
    }
}
