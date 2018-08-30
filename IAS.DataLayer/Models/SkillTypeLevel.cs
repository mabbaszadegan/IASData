namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillTypeLevel")]
    public partial class SkillTypeLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillTypeLevel()
        {
            PersonnelSkillType = new HashSet<PersonnelSkillType>();
            PersonSkillType = new HashSet<PersonSkillType>();
        }

        public int SkillTypeLevelId { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillTypeLevelName { get; set; }

        [StringLength(50)]
        public string SkillTypeLevelSummaryName { get; set; }

        [StringLength(100)]
        public string SkillTypeLevelZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonnelSkillType> PersonnelSkillType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonSkillType> PersonSkillType { get; set; }
    }
}
