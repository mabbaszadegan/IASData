namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsuranceType")]
    public partial class InsuranceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsuranceType()
        {
            DepartmentInsuranceType = new HashSet<DepartmentInsuranceType>();
            Person = new HashSet<Person>();
            PersonInsuranceType = new HashSet<PersonInsuranceType>();
        }

        public int InsuranceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceTypeName { get; set; }

        [StringLength(50)]
        public string InsuranceTypeSummaryName { get; set; }

        [StringLength(100)]
        public string InsuranceTypeZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentInsuranceType> DepartmentInsuranceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonInsuranceType> PersonInsuranceType { get; set; }
    }
}
