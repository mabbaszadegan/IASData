namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expertise")]
    public partial class Expertise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expertise()
        {
            PersonTeam = new HashSet<PersonTeam>();
            PersonTeamGrade = new HashSet<PersonTeamGrade>();
        }

        public int ExpertiseId { get; set; }

        public int SkillTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ExpertiseName { get; set; }

        [StringLength(100)]
        public string ExpertiseZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual SkillType SkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeam> PersonTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade { get; set; }
    }
}
