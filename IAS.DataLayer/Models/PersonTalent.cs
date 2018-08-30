namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonTalent")]
    public partial class PersonTalent
    {
        public int PersonTalentId { get; set; }

        [Required]
        [StringLength(10)]
        public string PersonTalentDateSolar { get; set; }

        public DateTime PersonTalentDate { get; set; }

        public double? Sprint100MRecord { get; set; }

        public double? Sprint200MRecord { get; set; }

        public double? Sprint540MRecord { get; set; }

        public double? Sprint2000MRecord { get; set; }

        public double? SargentJumpRecord { get; set; }

        public double? LongJumpRecord { get; set; }

        [StringLength(2000)]
        public string SpecialSkills { get; set; }

        public bool FootballSuitable { get; set; }

        public bool VolleyballSuitable { get; set; }

        public bool BasketballSuitable { get; set; }

        public bool SprintSuitable { get; set; }

        public bool MartialSuitable { get; set; }

        [StringLength(2000)]
        public string OtherSuitableSports { get; set; }

        [StringLength(2000)]
        public string FavoriteSports { get; set; }

        [StringLength(4000)]
        public string PersonTalentZiped { get; set; }

        public int PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }
    }
}
