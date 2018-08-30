namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DepartmentEthnic")]
    public partial class DepartmentEthnic
    {
        public int DepartmentEthnicId { get; set; }

        public int DepartmentId { get; set; }

        public int EthnicId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Department Department { get; set; }

        public virtual Ethnic Ethnic { get; set; }
    }
}
