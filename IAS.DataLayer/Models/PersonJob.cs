namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonJob")]
    public partial class PersonJob
    {
        public int PersonJobId { get; set; }

        public int PersonId { get; set; }

        public int? JobId { get; set; }

        [StringLength(4000)]
        public string PersonJobDesc { get; set; }

        [Column(TypeName = "money")]
        public decimal? PersonJobSalary { get; set; }

        [StringLength(4000)]
        public string PersonJobAddress { get; set; }

        [StringLength(4000)]
        public string PersonJobZiped { get; set; }

        public DateTime? PersonJobStartDate { get; set; }

        [StringLength(10)]
        public string PersonJobStartDateSolar { get; set; }

        public DateTime? PersonJobLeaveDate { get; set; }

        [StringLength(10)]
        public string PersonJobLeaveDateSolar { get; set; }

        [StringLength(2000)]
        public string PersonJobLeaveDesc { get; set; }

        public DateTime? PersonJobFinishDate { get; set; }

        [StringLength(10)]
        public string PersonJobFinishDateSolar { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Job Job { get; set; }

        public virtual Person Person { get; set; }
    }
}
