namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompetitionType")]
    public partial class CompetitionType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompetitionType()
        {
            Competition = new HashSet<Competition>();
        }

        public int CompetitionTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompetitionTypeName { get; set; }

        [StringLength(50)]
        public string CompetitionTypeSummaryName { get; set; }

        [StringLength(100)]
        public string CompetitionTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competition> Competition { get; set; }
    }
}
