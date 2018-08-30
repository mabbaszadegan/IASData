namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonInsuranceType")]
    public partial class PersonInsuranceType
    {
        public int PersonInsuranceTypeId { get; set; }

        public int PersonId { get; set; }

        public int InsuranceTypeId { get; set; }

        [StringLength(500)]
        public string InsuranceTypeDesc { get; set; }

        [StringLength(500)]
        public string InsuranceTypeName { get; set; }

        [StringLength(500)]
        public string InsuranceTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Person Person { get; set; }
    }
}
