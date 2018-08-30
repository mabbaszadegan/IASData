namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonTeam")]
    public partial class PersonTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonTeam()
        {
            PersonTeamGrade = new HashSet<PersonTeamGrade>();
            PersonTeamGrade1 = new HashSet<PersonTeamGrade>();
        }

        public int PersonTeamId { get; set; }

        public int PersonId { get; set; }

        public int DepartmentTeamId { get; set; }

        public DateTime? PersonEnterToTeamDate { get; set; }

        [StringLength(10)]
        public string PersonEnterToTeamDateSolar { get; set; }

        public DateTime? PersonExitFromTeamDate { get; set; }

        [StringLength(10)]
        public string PersonExitFromTeamDateSolar { get; set; }

        [StringLength(2000)]
        public string PersonExitFromTeamCause { get; set; }

        [StringLength(2000)]
        public string PersonTeamDesc { get; set; }

        [StringLength(2000)]
        public string PersonTeamZiped { get; set; }

        public bool IsCaptain { get; set; }

        public int? ShirtNo { get; set; }

        public int? ExpertiseId { get; set; }

        public int? BeltColorId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual BeltColor BeltColor { get; set; }

        public virtual DepartmentTeam DepartmentTeam { get; set; }

        public virtual Expertise Expertise { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade1 { get; set; }
    }
}
