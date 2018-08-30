namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonIdentityDocument")]
    public partial class PersonIdentityDocument
    {
        public int PersonIdentityDocumentId { get; set; }

        public int PersonId { get; set; }

        public int IdentityDocumentId { get; set; }

        [StringLength(50)]
        public string IdentityDocumentCode { get; set; }

        [StringLength(50)]
        public string IdentityDocumentSerialNo { get; set; }

        [StringLength(4000)]
        public string PersonIdentityDocumentDesc { get; set; }

        public DateTime? ExpireTime { get; set; }

        [StringLength(10)]
        public string ExpireTimeSolar { get; set; }

        [StringLength(4000)]
        public string PersonIdentityDocumenZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual IdentityDocument IdentityDocument { get; set; }

        public virtual Person Person { get; set; }
    }
}
