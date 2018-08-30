namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyPhone")]
    public partial class FamilyPhone
    {
        public int FamilyPhoneId { get; set; }

        public int FamilyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(2000)]
        public string FamilyPhoneDesc { get; set; }

        [StringLength(2000)]
        public string FamilyPhoneZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Family Family { get; set; }
    }
}
