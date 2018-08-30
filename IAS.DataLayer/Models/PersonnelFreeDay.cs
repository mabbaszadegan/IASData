namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelFreeDay")]
    public partial class PersonnelFreeDay
    {
        public int PersonnelFreeDayId { get; set; }

        public int PersonnelId { get; set; }

        public int WeekDayId { get; set; }

        [Required]
        [StringLength(5)]
        public string FreeTimeFrom { get; set; }

        [Required]
        [StringLength(5)]
        public string FreeTimeTo { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual WeekDay WeekDay { get; set; }
    }
}
