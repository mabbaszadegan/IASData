namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentCrimeType")]
    public partial class DepartmentCrimeType
    {
        public int DepartmentCrimeTypeId { get; set; }

        public int DepartmentId { get; set; }

        public int CrimeTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual CrimeType CrimeType { get; set; }

        public virtual Department Department { get; set; }
    }
}
