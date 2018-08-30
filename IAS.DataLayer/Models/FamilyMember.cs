namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyMember")]
    public partial class FamilyMember
    {
        public int FamilyMemberId { get; set; }

        public int FamilyId { get; set; }

        public int PersonId { get; set; }

        public bool FamilyMemberIsParent { get; set; }

        public DateTime? FamilyMemberExpireTime { get; set; }

        [StringLength(16)]
        public string FamilyMemberExpireTimeSolar { get; set; }

        public int? ExpireCauseId { get; set; }

        public int RelationTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual ExpireCause ExpireCause { get; set; }

        public virtual Family Family { get; set; }

        public virtual Person Person { get; set; }

        public virtual RelationType RelationType { get; set; }
    }
}
