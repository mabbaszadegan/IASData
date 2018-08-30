namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonCrimeType")]
    public partial class PersonCrimeType
    {
        public int PersonCrimeTypeId { get; set; }

        public int PersonId { get; set; }

        public int CrimeTypeId { get; set; }

        public int PunishmentStatusId { get; set; }

        public int PunishmentTypeId { get; set; }

        [StringLength(2000)]
        public string PunishmentTypeDesc { get; set; }

        [StringLength(16)]
        public string PunishmentStartTimeSolar { get; set; }

        public DateTime? PunishmentStartTime { get; set; }

        [StringLength(16)]
        public string PunishmentFinishTimeSolar { get; set; }

        public DateTime? PunishmentFinishTime { get; set; }

        public int? PunishmentCheckOutCauseId { get; set; }

        [StringLength(16)]
        public string PunishmentCheckOutTimeSolar { get; set; }

        public DateTime? PunishmentCheckOutTime { get; set; }

        [StringLength(4000)]
        public string PersonCrimeTypeDesc { get; set; }

        [StringLength(4000)]
        public string PersonCrimeTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual CrimeType CrimeType { get; set; }

        public virtual Person Person { get; set; }

        public virtual PunishmentCheckOutCause PunishmentCheckOutCause { get; set; }

        public virtual PunishmentStatus PunishmentStatus { get; set; }

        public virtual PunishmentType PunishmentType { get; set; }
    }
}
