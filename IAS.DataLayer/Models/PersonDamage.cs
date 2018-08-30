namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonDamage")]
    public partial class PersonDamage
    {
        public int PersonDamageId { get; set; }

        public int PersonId { get; set; }

        [StringLength(4)]
        public string PersonDamageYear { get; set; }

        [StringLength(2)]
        public string PersonDamageMonth { get; set; }

        [StringLength(2)]
        public string PersonDamageDay { get; set; }

        public DateTime? PersonDamageDate { get; set; }

        [StringLength(10)]
        public string PersonDamageDateSolar { get; set; }

        public int DamageCauseId { get; set; }

        [StringLength(2000)]
        public string DamageCauseDesc { get; set; }

        public int DamagedLimbId { get; set; }

        [StringLength(2000)]
        public string DamagedLimbDesc { get; set; }

        public bool HasSurgery { get; set; }

        [StringLength(2000)]
        public string SurgeryDesc { get; set; }

        [StringLength(2000)]
        public string PersonDamageZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual DamageCause DamageCause { get; set; }

        public virtual Limb Limb { get; set; }

        public virtual Person Person { get; set; }
    }
}
