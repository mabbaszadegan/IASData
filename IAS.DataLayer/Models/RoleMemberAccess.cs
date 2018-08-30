namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMemberAccess")]
    public partial class RoleMemberAccess
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleMemberAccessId { get; set; }

        public int RoleMemberId { get; set; }

        public int PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual RoleMember RoleMember { get; set; }
    }
}
