namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            DepartmentJob = new HashSet<DepartmentJob>();
            Person = new HashSet<Person>();
            PersonJob = new HashSet<PersonJob>();
            Personnel = new HashSet<Personnel>();
        }

        public int JobId { get; set; }

        [Required]
        [StringLength(70)]
        public string JobName { get; set; }

        [StringLength(4000)]
        public string JobDesc { get; set; }

        [Required]
        [StringLength(4000)]
        public string JobZiped { get; set; }

        public bool JobIsActive { get; set; }

        public bool JobIsDangerous { get; set; }

        public int JobStatusId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentJob> DepartmentJob { get; set; }

        public virtual JobStatus JobStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonJob> PersonJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
