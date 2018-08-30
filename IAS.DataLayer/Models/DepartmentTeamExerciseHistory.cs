namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentTeamExerciseHistory")]
    public partial class DepartmentTeamExerciseHistory
    {
        public int DepartmentTeamExerciseHistoryId { get; set; }

        public int? DepartmentTeamExerciseTimeId { get; set; }

        public int DepartmentTeamId { get; set; }

        [Required]
        [StringLength(16)]
        public string ExerciseStartTimeSolar { get; set; }

        public DateTime ExerciseStartTime { get; set; }

        [Required]
        [StringLength(16)]
        public string ExerciseFinishTimeSolar { get; set; }

        public DateTime ExerciseFinishTime { get; set; }

        [StringLength(500)]
        public string Place { get; set; }

        [StringLength(2000)]
        public string ExerciseDesc { get; set; }

        [StringLength(2000)]
        public string DepartmentTeamExerciseTimeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DepartmentTeam DepartmentTeam { get; set; }

        public virtual DepartmentTeamExerciseTime DepartmentTeamExerciseTime { get; set; }
    }
}
