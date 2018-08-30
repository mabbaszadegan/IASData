namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HousePhone")]
    public partial class HousePhone
    {
        public int HousePhoneId { get; set; }

        public int HouseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(2000)]
        public string HousePhoneDesc { get; set; }

        [StringLength(2000)]
        public string HousePhoneZiped { get; set; }

        public int? PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
