namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonWorkshop")]
    public partial class PersonWorkshop
    {
        public int PersonWorkshopId { get; set; }

        public int PersonId { get; set; }

        public int WorkshopId { get; set; }

        [Required]
        [StringLength(10)]
        public string PersonWorkshopDateSolar { get; set; }

        public DateTime PersonWorkshopDate { get; set; }

        [StringLength(3000)]
        public string PersonWorkshopDesc { get; set; }

        [StringLength(3000)]
        public string PersonWorkshopZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
