namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentEducationField")]
    public partial class DepartmentEducationField
    {
        public int DepartmentEducationFieldId { get; set; }

        public int DepartmentId { get; set; }

        public int EducationFieldId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual EducationField EducationField { get; set; }
    }
}
