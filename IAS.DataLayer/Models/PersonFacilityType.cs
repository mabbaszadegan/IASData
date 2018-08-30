namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonFacilityType")]
    public partial class PersonFacilityType
    {
        public int PersonFacilityTypeId { get; set; }

        public int PersonId { get; set; }

        public int FacilityTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime ChangeTime { get; set; }

        public virtual FacilityType FacilityType { get; set; }

        public virtual Person Person { get; set; }
    }
}
