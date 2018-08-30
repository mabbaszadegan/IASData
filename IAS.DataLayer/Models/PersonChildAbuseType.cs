namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonChildAbuseType")]
    public partial class PersonChildAbuseType
    {
        public int PersonChildAbuseTypeId { get; set; }

        public int PersonId { get; set; }

        public int ChildAbuseTypeId { get; set; }

        [StringLength(4000)]
        public string PersonChildAbuseTypeDesc { get; set; }

        [StringLength(4000)]
        public string PersonChildAbuseTypeZiped { get; set; }

        public int? RelationTypeId { get; set; }

        [StringLength(500)]
        public string AbuserName { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual ChildAbuseType ChildAbuseType { get; set; }

        public virtual Person Person { get; set; }

        public virtual RelationType RelationType { get; set; }
    }
}
