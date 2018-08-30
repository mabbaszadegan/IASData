namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonTraningCourseType")]
    public partial class PersonTraningCourseType
    {
        public int PersonTraningCourseTypeId { get; set; }

        public int PersonId { get; set; }

        public int TraningCourseTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string PersonTraningCourseTypeDateSolar { get; set; }

        public DateTime PersonTraningCourseTypeDate { get; set; }

        [StringLength(3000)]
        public string PersonTraningCourseTypeDesc { get; set; }

        [StringLength(3000)]
        public string PersonTraningCourseTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual TraningCourseType TraningCourseType { get; set; }
    }
}
