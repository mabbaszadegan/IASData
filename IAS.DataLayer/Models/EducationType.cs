namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationType")]
    public partial class EducationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationType()
        {
            DepartmentEducationType = new HashSet<DepartmentEducationType>();
            Person = new HashSet<Person>();
            Personnel = new HashSet<Personnel>();
        }

        public int EducationTypeId { get; set; }

        public int? EducationTypeIndex { get; set; }

        [Required]
        [StringLength(50)]
        public string EducationTypeName { get; set; }

        [StringLength(50)]
        public string EducationTypeSummaryName { get; set; }

        [StringLength(100)]
        public string EducationTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentEducationType> DepartmentEducationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
