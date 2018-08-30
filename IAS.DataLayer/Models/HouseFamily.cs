namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseFamily")]
    public partial class HouseFamily
    {
        public int HouseFamilyId { get; set; }

        public int HouseId { get; set; }

        public int? FamilyId { get; set; }

        [StringLength(10)]
        public string HouseLoginDateSolar { get; set; }

        public DateTime? HouseLoginDate { get; set; }

        [StringLength(10)]
        public string HouseLeaveDateSolar { get; set; }

        public DateTime? HouseLeaveDate { get; set; }

        public int? LeavingHouseCauseId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Family Family { get; set; }

        public virtual House House { get; set; }

        public virtual LeavingHouseCause LeavingHouseCause { get; set; }
    }
}
