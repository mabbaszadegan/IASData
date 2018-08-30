namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonnelWorkshop")]
    public partial class PersonnelWorkshop
    {
        public int PersonnelWorkshopId { get; set; }

        public int PersonnelId { get; set; }

        public int WorkshopId { get; set; }

        [Required]
        [StringLength(10)]
        public string PersonnelWorkshopDateSolar { get; set; }

        public DateTime PersonnelWorkshopDate { get; set; }

        [StringLength(3000)]
        public string PersonnelWorkshopDesc { get; set; }

        [StringLength(3000)]
        public string PersonnelWorkshopZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
