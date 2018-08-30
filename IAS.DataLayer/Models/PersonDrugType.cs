namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDrugType")]
    public partial class PersonDrugType
    {
        public int PersonDrugTypeId { get; set; }

        public int PersonId { get; set; }

        public int DrugTypeId { get; set; }

        public int? PersonDrugTypeDuration { get; set; }

        [StringLength(4)]
        public string DrugStartYear { get; set; }

        [StringLength(2000)]
        public string DrugStartCause { get; set; }

        [StringLength(2000)]
        public string DrugDesc { get; set; }

        [StringLength(4)]
        public string DrugStopYear { get; set; }

        [StringLength(2000)]
        public string DrugStopCause { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DrugType DrugType { get; set; }

        public virtual Person Person { get; set; }
    }
}
