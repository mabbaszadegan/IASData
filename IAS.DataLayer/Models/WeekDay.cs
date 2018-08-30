namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeekDay")]
    public partial class WeekDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WeekDay()
        {
            DepartmentTeamExerciseTime = new HashSet<DepartmentTeamExerciseTime>();
            PersonnelFreeDay = new HashSet<PersonnelFreeDay>();
        }

        public int WeekDayId { get; set; }

        [Required]
        [StringLength(50)]
        public string WeekDayName { get; set; }

        [StringLength(50)]
        public string WeekDaySummaryName { get; set; }

        [StringLength(100)]
        public string WeekDayZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentTeamExerciseTime> DepartmentTeamExerciseTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelFreeDay> PersonnelFreeDay { get; set; }
    }
}
