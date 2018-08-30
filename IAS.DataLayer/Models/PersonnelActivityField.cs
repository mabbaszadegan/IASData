namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelActivityField")]
    public partial class PersonnelActivityField
    {
        public int PersonnelActivityFieldId { get; set; }

        public int PersonnelId { get; set; }

        public int ActivityFieldId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual ActivityField ActivityField { get; set; }

        public virtual Personnel Personnel { get; set; }
    }
}
