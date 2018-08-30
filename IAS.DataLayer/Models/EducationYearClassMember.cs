namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationYearClassMember")]
    public partial class EducationYearClassMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationYearClassMember()
        {
            EducationYearClassMemberHistory = new HashSet<EducationYearClassMemberHistory>();
        }

        public int EducationYearClassMemberId { get; set; }

        public int EducationYearClassId { get; set; }

        public int PersonId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual EducationYearClass EducationYearClass { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationYearClassMemberHistory> EducationYearClassMemberHistory { get; set; }
    }
}
