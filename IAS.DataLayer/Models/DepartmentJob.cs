namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentJob")]
    public partial class DepartmentJob
    {
        public int DepartmentJobId { get; set; }

        public int DepartmentId { get; set; }

        public int JobId { get; set; }

        public bool ForPerson { get; set; }

        public bool ForPersonnel { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual Job Job { get; set; }
    }
}
