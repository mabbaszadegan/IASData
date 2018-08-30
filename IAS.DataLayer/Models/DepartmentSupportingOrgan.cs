namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentSupportingOrgan")]
    public partial class DepartmentSupportingOrgan
    {
        public int DepartmentSupportingOrganId { get; set; }

        public int DepartmentId { get; set; }

        public int SupportingOrganId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual SupportingOrgan SupportingOrgan { get; set; }
    }
}
