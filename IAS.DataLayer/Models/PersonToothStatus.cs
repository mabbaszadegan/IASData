namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PersonToothStatus
    {
        public int PersonToothStatusId { get; set; }

        public int PersonDentalMonitoringId { get; set; }

        public short ToothId { get; set; }

        public int ToothStatusId { get; set; }

        [StringLength(4000)]
        public string PersonToothStatusDesc { get; set; }

        [StringLength(4000)]
        public string PersonToothStatusZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual PersonDentalMonitoring PersonDentalMonitoring { get; set; }

        public virtual Tooth Tooth { get; set; }

        public virtual ToothStatus ToothStatus { get; set; }
    }
}
