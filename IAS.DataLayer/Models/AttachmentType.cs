namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttachmentType")]
    public partial class AttachmentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttachmentType()
        {
            Attachment = new HashSet<Attachment>();
        }

        public int AttachmentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string AttachmentTypeName { get; set; }

        [Required]
        [StringLength(100)]
        public string AttachmentTypeZiped { get; set; }

        public int AttachmentTypeMaxSize { get; set; }

        [Required]
        [StringLength(200)]
        public string AttachmentTypeAllowedFormat { get; set; }

        public int ObjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string ObjectName { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
