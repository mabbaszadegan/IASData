namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attachment")]
    public partial class Attachment
    {
        public int AttachmentId { get; set; }

        [StringLength(500)]
        public string AttachmentDesc { get; set; }

        [Required]
        [StringLength(500)]
        public string AttachmentFileName { get; set; }

        [Required]
        [StringLength(500)]
        public string AttachmentExtention { get; set; }

        [Required]
        public byte[] AttachmentContent { get; set; }

        [Required]
        [StringLength(500)]
        public string AttachmentContentType { get; set; }

        public DateTime AttachmentTime { get; set; }

        [Required]
        [StringLength(16)]
        public string AttachmentTimeSolar { get; set; }

        public bool AttachmentIsDefault { get; set; }

        public double? AttachmentLatitudeDevice { get; set; }

        public double? AttachmentLongitudeDevice { get; set; }

        public int AttachmentTypeId { get; set; }

        public long AttachmentOwnerId { get; set; }

        [Required]
        [StringLength(4000)]
        public string AttachmentZiped { get; set; }

        public int? RoleId { get; set; }

        public int UserId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual AttachmentType AttachmentType { get; set; }
    }
}
