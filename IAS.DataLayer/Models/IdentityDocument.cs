namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IdentityDocument")]
    public partial class IdentityDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentityDocument()
        {
            PersonIdentityDocument = new HashSet<PersonIdentityDocument>();
        }

        public int IdentityDocumentId { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentityDocumentName { get; set; }

        [StringLength(50)]
        public string IdentityDocumentSummaryName { get; set; }

        [StringLength(100)]
        public string IdentityDocumentZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonIdentityDocument> PersonIdentityDocument { get; set; }
    }
}
