namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentResidenceType")]
    public partial class DepartmentResidenceType
    {
        public int DepartmentResidenceTypeId { get; set; }

        public int DepartmentId { get; set; }

        public int ResidenceTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual ResidenceType ResidenceType { get; set; }
    }
}
