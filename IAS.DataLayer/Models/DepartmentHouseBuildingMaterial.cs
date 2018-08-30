namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentHouseBuildingMaterial")]
    public partial class DepartmentHouseBuildingMaterial
    {
        public int DepartmentHouseBuildingMaterialId { get; set; }

        public int DepartmentId { get; set; }

        public int HouseBuildingMaterialId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual HouseBuildingMaterial HouseBuildingMaterial { get; set; }
    }
}
