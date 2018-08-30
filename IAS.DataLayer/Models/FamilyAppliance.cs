namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyAppliance")]
    public partial class FamilyAppliance
    {
        public int FamilyApplianceId { get; set; }

        public int FamilyId { get; set; }

        public int ApplianceId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Appliance Appliance { get; set; }

        public virtual Family Family { get; set; }
    }
}
