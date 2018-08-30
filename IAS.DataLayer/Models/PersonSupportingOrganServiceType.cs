namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSupportingOrganServiceType")]
    public partial class PersonSupportingOrganServiceType
    {
        public int PersonSupportingOrganServiceTypeId { get; set; }

        public int PersonSupportingOrganId { get; set; }

        public int ServiceTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual PersonSupportingOrgan PersonSupportingOrgan { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}
