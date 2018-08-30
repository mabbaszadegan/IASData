namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentEducationType")]
    public partial class DepartmentEducationType
    {
        public int DepartmentEducationTypeId { get; set; }

        public int DepartmentId { get; set; }

        public int EducationTypeId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual EducationType EducationType { get; set; }
    }
}
