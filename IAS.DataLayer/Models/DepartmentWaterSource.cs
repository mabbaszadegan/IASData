namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentWaterSource")]
    public partial class DepartmentWaterSource
    {
        public int DepartmentWaterSourceId { get; set; }

        public int DepartmentId { get; set; }

        public int WaterSourceId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual WaterSource WaterSource { get; set; }
    }
}
