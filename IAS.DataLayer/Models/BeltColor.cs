namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BeltColor")]
    public partial class BeltColor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BeltColor()
        {
            PersonTeam = new HashSet<PersonTeam>();
            PersonTeamGrade = new HashSet<PersonTeamGrade>();
        }

        public int BeltColorId { get; set; }

        [StringLength(50)]
        public string BeltColorName { get; set; }

        [StringLength(100)]
        public string BeltColorZiped { get; set; }

        public int SkillTypeId { get; set; }

        public int ColorId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Color Color { get; set; }

        public virtual SkillType SkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeam> PersonTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonTeamGrade> PersonTeamGrade { get; set; }
    }
}
